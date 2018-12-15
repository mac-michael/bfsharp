using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace BFsharp.DynamicProperties
{
    public class DynamicObjectEmitter
    {
        protected DynamicObjectEmitter() { }
        static DynamicObjectEmitter()
        {
            Emitter = new DynamicObjectEmitter();
        }
        public static DynamicObjectEmitter Emitter { get; private set; }

        private static AssemblyBuilder _assmblyBuilder;
        private static ModuleBuilder _moduleBuilder;

        private static void GenerateAssemblyAndModule()
        {
            if (_assmblyBuilder == null)
            {
                var assemblyName = new AssemblyName { Name = "DynamicObjectEmitter" };
                const AssemblyBuilderAccess access =
#if SILVERLIGHT
                    AssemblyBuilderAccess.Run;
#else
                    AssemblyBuilderAccess.RunAndSave;
#endif

                AppDomain thisDomain = AppDomain.CurrentDomain;
                _assmblyBuilder = thisDomain.DefineDynamicAssembly(assemblyName, access);

                _moduleBuilder = _assmblyBuilder.DefineDynamicModule(
                    assemblyName.Name,
#if !SILVERLIGHT
                    assemblyName.Name + ".dll",
#endif
                    true);
            }
        }

        private static TypeBuilder CreateType(string typeName)
        {
            TypeBuilder typeBuilder = _moduleBuilder.DefineType(typeName,
                                                                TypeAttributes.Public |
                                                                TypeAttributes.Class |
                                                                TypeAttributes.AutoClass |
                                                                TypeAttributes.AnsiClass |
                                                                TypeAttributes.BeforeFieldInit |
                                                                TypeAttributes.AutoLayout,
                                                                typeof(TypedProxyBase),
                                                                new Type[] { });

            return typeBuilder;
        }

        private static void CreateConstructor(TypeBuilder typeBuilder)
        {
            ConstructorBuilder constructor = typeBuilder.DefineConstructor(
                MethodAttributes.Public |
                MethodAttributes.SpecialName |
                MethodAttributes.RTSpecialName,
                CallingConventions.Standard,
                new[] { typeof(DynamicPropertyCollection) });

            ConstructorInfo conObj = typeof(TypedProxyBase).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(DynamicPropertyCollection) }, null);

            // Call constructor of the base object
            ILGenerator il = constructor.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, conObj);
            il.Emit(OpCodes.Ret);
        }

        private static void CreateProperty(TypeBuilder typeBuilder, string name, Type type, FieldInfo parentField)
        {
            var propertyBuilder = typeBuilder.DefineProperty(name, PropertyAttributes.None,
                                                             type, new Type[0]);
            
            MethodBuilder get = CreateGetMethod(typeBuilder, name, type, parentField);
            propertyBuilder.SetGetMethod(get);

            MethodBuilder set = CreateSetMethod(typeBuilder, name, type, parentField);
            propertyBuilder.SetSetMethod(set);
        }

        private static MethodBuilder CreateGetMethod(TypeBuilder typeBuilder, string name,
            Type type, FieldInfo parentField)
        {
            MethodBuilder get = typeBuilder.DefineMethod("get_" + name, MethodAttributes.Public
                                                                        | MethodAttributes.HideBySig | MethodAttributes.SpecialName,
                                                         type, new Type[0]);


            var gen = get.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldfld, parentField);
            gen.Emit(OpCodes.Ldstr, name);

            var method = typeof (DynamicPropertyCollection).GetMethod("GetProperty")
                .MakeGenericMethod(type);

            gen.Emit(OpCodes.Callvirt, method);
            gen.Emit(OpCodes.Ret);
            return get;
        }

        private static MethodBuilder CreateSetMethod(TypeBuilder typeBuilder, string name, Type type, FieldInfo parentField)
        {
            MethodBuilder set = typeBuilder.DefineMethod("set_" + name, MethodAttributes.Public
                                                                        | MethodAttributes.HideBySig | MethodAttributes.SpecialName,
                                                         typeof(void), new[] { type });

            ILGenerator gen = set.GetILGenerator();

            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ldfld, parentField);
            gen.Emit(OpCodes.Ldstr, name);
            gen.Emit(OpCodes.Ldarg_1);

            var method = typeof(DynamicPropertyCollection).GetMethod("SetProperty")
                .MakeGenericMethod(type);

            gen.Emit(OpCodes.Callvirt, method);

            gen.Emit(OpCodes.Ret);
            return set;
        }

#if !SILVERLIGHT
        public void SaveAssembly()
        {
            _assmblyBuilder.Save(_assmblyBuilder.GetName().Name + ".dll");

            _assmblyBuilder = null;
        }
#endif

        private static Func<DynamicPropertyCollection, TypedProxyBase> Create(IEnumerable<DynamicPropertyMetadata> properties)
        {
            GenerateAssemblyAndModule();

            TypeBuilder typeBuilder = CreateType(Guid.NewGuid().ToString());
            CreateConstructor(typeBuilder);

            var parentField = typeof(TypedProxyBase).GetField("_parent", BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var property in properties)
                CreateProperty(typeBuilder, property.Name, property.Type, parentField);

            var dynamicType = typeBuilder.CreateType();
            var constructor = dynamicType.GetConstructor(new[] {typeof (DynamicPropertyCollection)});
            Debug.WriteLine("Type: " + dynamicType + " created.");
            var p = Expression.Parameter(typeof (DynamicPropertyCollection), "p");

            var func = Expression.Lambda<Func<DynamicPropertyCollection, TypedProxyBase>>(
                Expression.New(constructor, p), p).Compile();

            return func;
        }

        private static string BuildKey(IEnumerable<DynamicPropertyMetadata> properties)
        {
            var key = new StringBuilder();
            foreach (var p in properties)
            {
                string handle;
#if SILVERLIGHT
                handle = p.Type.AssemblyQualifiedName;
#elif NET
                handle = p.Type.TypeHandle.Value.ToString();
#endif
                key.AppendFormat("{0};{1};{2};", handle, p.Type.Module.MetadataToken, p.Name);
            }

            return key.ToString();
        }

        private static readonly IDictionary<string, Func<DynamicPropertyCollection, TypedProxyBase>> _cache =
#if Net40
            new  System.Collections.Concurrent.ConcurrentDictionary<string, Func<DynamicPropertyCollection, TypedProxyBase>>();
#else
            new Dictionary<string, Func<DynamicPropertyCollection, TypedProxyBase>>();
#endif

        public Func<DynamicPropertyCollection, TypedProxyBase> CreateDynamicObjectCreator(IEnumerable<DynamicPropertyMetadata> properties)
        {
            var key = BuildKey(properties);
            Func<DynamicPropertyCollection, TypedProxyBase> f;

            lock (_cache)
                _cache.TryGetValue(key, out f);

            if (f == null)
            {
                f = Create(properties);
                lock (_cache)
                    _cache[key] = f;
            }

            return f;
        }
    }
}