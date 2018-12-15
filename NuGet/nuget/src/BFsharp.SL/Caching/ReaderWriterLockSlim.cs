using System.Threading;

namespace BFsharp
{
    internal class ReaderWriterLockSlim
    {
        private readonly object _lock = new object();

        public void ExitWriteLock()
        {
            Monitor.Exit(_lock);
        }

        public void EnterWriteLock()
        {
            Monitor.Enter(_lock);
        }

        public void ExitReadLock()
        {
            Monitor.Exit(_lock);
        }

        public void EnterReadLock()
        {
            Monitor.Enter(_lock);
        }
    }
}