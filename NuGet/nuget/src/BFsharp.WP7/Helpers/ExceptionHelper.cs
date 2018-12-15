using System;
using System.Threading;

namespace BFsharp
{
    internal static class ExceptionHelper
    {
        public static bool IsNonrecoverableException(Exception exception)
        {
            return exception is OutOfMemoryException || 
                exception is StackOverflowException || 
                exception is ThreadAbortException || 
                exception is AppDomainUnloadedException || 
                exception is ExecutionEngineException;
        }
    }
}