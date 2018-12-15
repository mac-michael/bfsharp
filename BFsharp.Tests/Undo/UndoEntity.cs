using System;

namespace BFsharp
{
    public class UndoEntityWithArray
    {
        public int[] Ints { get; set; }
    }

    public class UndoEntityWithInheritanceB : UndoEntityWithInheritance
    {
        public string PropertyInChild { get; set; }        
    }
    public class UndoEntityWithInheritance
    {
        public string PropertyInBase { get; set; }
    }

    [Serializable]
    public class UndoEntity
    {
        public UndoEntityLevel1 Entity { get; set; }
        public UndoEntityLevel1 Entity2 { get; set; }

        public string AutoProperty { get; set; }
        string PrivateAutoProperty { get; set; }

        public void SetPrivateAutoProperty(string value)
        {
            PrivateAutoProperty = value;
        }

        public string GetPrivateAutoProperty()
        {
            return PrivateAutoProperty;
        }

        public string MixedAutoProperty { get; private set; }

        public void SetMixedAutoProperty(string value)
        {
            MixedAutoProperty = value;    
        }

        private string _property;
        public string Property
        {
            get { return _property; }
            set { _property = value; }
        }

        private string _privateProperty;
        public string PrivateProperty
        {
            get { return _privateProperty; }
            set { _privateProperty = value; }
        }

        public string Field;
    }
}