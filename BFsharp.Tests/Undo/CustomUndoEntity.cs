using BFsharp.Undo;

namespace BFsharp
{
    public class CustomUndoEntity : IUndoable
    {
        public string UndoableProperty { get; set; }
        public string NonUndoableProperty { get; set; }

        public object[] SavepointImpl()
        {
            return new[] {UndoableProperty};
        }

        public void RollbackImpl(object[] state)
        {
            UndoableProperty = (string) state[0];
        }
    }
}