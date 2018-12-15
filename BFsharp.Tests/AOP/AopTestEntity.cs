using System;
using System.ComponentModel;
using BFsharp.AOP;

namespace BFsharp.Tests
{
    [NotifyPropertyChanged]
    public class AopTestEntity
    {
        public int A { get; set; }
        public string A2 { get; set; }

        [DontNotify]
        public string B { get; set; }

        private string Private { get; set; }
        protected string Protected { get; set; }
        public string PrivateSetter { get; private set; }
        public string ProtectedSetter { get; protected set; }

        [NotifiedBy("A", "A2")]
        public string CalculatedA { get { return A + A2; } }

        [NotifiedBy("CalculatedA")]
        public string RecursiveA { get { return CalculatedA + "2"; } }
    }

    [NotifyPropertyChanged]
    public class AopTestEntityWithNPC : INotifyPropertyChanged 
    {
        public int A { get; set; }
        public string A2 { get; set; }

        [DontNotify]
        public string B { get; set; }

        [NotifiedBy("A", "A2")]
        public string CalculatedA { get { return A + A2; } }

        [NotifiedBy("CalculatedA")]
        public string RecursiveA { get { return CalculatedA + "2"; } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
}