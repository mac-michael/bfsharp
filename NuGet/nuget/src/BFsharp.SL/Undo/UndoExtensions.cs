using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace BFsharp.Undo
{
    public interface IUndoable
    {
        object[] SavepointImpl();
        void RollbackImpl(object[] undoState);
    }

    public static class UndoExtensions
    {
        public abstract class UndoState
        {
            protected UndoState(object root)
            {
                _root = root;
                _state = new Dictionary<object, object[]>();
            }

            internal Dictionary<object, object[]> _state;
            //internal Dictionary<object, List<Func<T, object>>> _cache;
            internal object _root;
        }
        
        public sealed class UndoState<T> : UndoState, IDisposable
        {
            internal UndoState(T root) : base(root) {}

            public void Rollback()
            {
                InternalRollback((T) _root, this);
            }

            public void Dispose()
            {
                if (!_committed )
                    Rollback();
            }

            private bool _committed;
            public void Commit()
            {
                _committed = true;
            }
        }

        internal static class UndoDefinitions<T>
        {
            static UndoDefinitions()
            {
                Debug.WriteLine("Precompiling UndoDefinitions for " + typeof (T).Name);

                Definition = new UndoDefinition();

                foreach (var property in typeof (T).GetProperties(
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    var objectParameter = Expression.Parameter(typeof (object), "obj");
                    var valueParameter = Expression.Parameter(typeof (object), "value");

                    var getLambda = Expression.Lambda<Func<object, object>>(
                        Expression.Convert(
                            Expression.Property(Expression.Convert(objectParameter, typeof(T)), property), typeof(object)),
                        objectParameter);

                    var method = property.GetSetMethod(true);

                    if (method == null) continue;

                    var setLambda = Expression.Lambda<Action<object, object>>(
                        Expression.Call(
                            Expression.Convert(objectParameter, typeof (T)), method,
                            Expression.Convert(valueParameter, property.PropertyType)),
                        objectParameter, valueParameter);

                    var getState = getLambda.Compile();
                    var setState = setLambda.Compile();

                    Definition.GetStates.Add(getState);
                    Definition.SetStates.Add(setState);

                    // Recursive
                    if (ShouldSavepoint(property.PropertyType))
                    {
                        var stateParameter = Expression.Parameter(typeof (UndoState), "state");

                        var savepoint = typeof (UndoExtensions).GetMethod("InternalSavepoint",
                                                                          BindingFlags.Static | BindingFlags.NonPublic);
                        var rollback = typeof (UndoExtensions).GetMethod("InternalRollback",
                                                                         BindingFlags.Static | BindingFlags.NonPublic);
                        savepoint = savepoint.MakeGenericMethod(property.PropertyType);
                        rollback = rollback.MakeGenericMethod(property.PropertyType);

                        var saveLambda = Expression.Lambda<Action<object, UndoState>>(
                            Expression.Call(savepoint,
                                            Expression.Property(
                                                Expression.Convert(objectParameter, typeof (T)), property),
                                            stateParameter),
                            objectParameter, stateParameter);

                        var rollbackLambda = Expression.Lambda<Action<object, UndoState>>(
                            Expression.Call(rollback,
                                            Expression.Property(
                                                Expression.Convert(objectParameter, typeof (T)),
                                                property), stateParameter),
                            objectParameter, stateParameter);

                        var save = saveLambda.Compile();
                        var back = rollbackLambda.Compile();
                        Definition.Save.Add(save);
                        Definition.Rollback.Add(back);
                    }
                }
            }

            // ShouldDeepCopy?
            private static bool ShouldSavepoint(Type type)
            {
                return !type.IsValueType && !type.IsArray && type != typeof(string);
            }

            internal static readonly UndoDefinition Definition;
        }

        internal class UndoDefinition
        {
            internal List<Func<object, object>> GetStates = new List<Func<object, object>>();
            internal List<Action<object, object>> SetStates = new List<Action<object, object>>();
            internal List<Action<object, UndoState>> Save = new List<Action<object, UndoState>>();
            internal List<Action<object, UndoState>> Rollback = new List<Action<object, UndoState>>();
        }

        public static UndoState<T> Savepoint<T>(this T obj) where T : class
        {
            var undo = new UndoState<T>(obj);

            InternalSavepoint(obj, undo);

            return undo;
        }
        
        static readonly Type Typedef = typeof(UndoDefinitions<>);

        private static void InternalSavepoint<T>(T obj, UndoState undoState)
        {
            if (obj == null || undoState._state.ContainsKey(obj)) return;

            var genType = Typedef.MakeGenericType(obj.GetType());

            var definition = (UndoDefinition)genType.GetField("Definition",
                BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);

            object[] objState;
            if (obj is IUndoable)
                objState = ((IUndoable) obj).SavepointImpl();
            else
            {

                var getStates = definition.GetStates;
                objState = new object[getStates.Count];

                // Members
                for (int i = 0; i < getStates.Count; i++)
                    objState[i] = getStates[i](obj);
            }

            undoState._state[obj] = objState;

            // Recursive
            var savepoint = definition.Save;
            for (int i = 0; i < savepoint.Count; i++)
                savepoint[i](obj, undoState);
        }

        private static void InternalRollback<T>(T obj, UndoState undoState)
        {
            if (obj == null) return;

            object[] state;
            if (!undoState._state.TryGetValue(obj, out state))
                return;
            undoState._state.Remove(obj);

            var genType = Typedef.MakeGenericType(obj.GetType());

            var definition = (UndoDefinition)genType.GetField("Definition",
                BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);

            if (obj is IUndoable)
                ((IUndoable) obj).RollbackImpl(state);
            else
            {
                var setStates = definition.SetStates;

                // Members
                for (int i = 0; i < setStates.Count; i++)
                    setStates[i](obj, state[i]);
            }

            // Recursive
            var rollback = definition.Rollback;
            for (int i = 0; i < rollback.Count; i++)
                rollback[i](obj, undoState);
        }
    }
}