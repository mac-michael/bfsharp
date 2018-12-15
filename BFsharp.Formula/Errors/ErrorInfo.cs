namespace BFsharp.Formula
{
    public class ErrorInfo
    {
        public string Text { get; set; }

        public int Number { get; set; }

        public int Line { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
            return string.Format("({0}:{1}): error {2}: {3}", Line, Column, Number, Text);
        }
    }
}