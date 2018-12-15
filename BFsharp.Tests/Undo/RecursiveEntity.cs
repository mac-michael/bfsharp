using System;

namespace BFsharp
{
    public class RecursiveEntity
    {
        public RecursiveEntity Other { get; set; }
        public int Value { get; set; }
    }

    public class UndoEntityLevel2
    {
        public string Name { get; set; }
    }

    public class UndoEntityWithStruct
    {
        public UndoStruct Struct { get; set; }
    }

    public struct UndoStruct
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public UndoEntityLevel2 Level2 { get; set; }

        public void SetName(string newName)
        {
            Name = newName;
        }
    }
}