namespace BFsharp.Formula
{
    public class BuildInfoItem
    {
        public BuildInfoItem() {}

        public BuildInfoItem( string message, FormulaCompilerBuildInfoLevels type)
        {
            Message = message;
            Type = type;
        }

        public FormulaCompilerBuildInfoLevels Type { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            if (Type != FormulaCompilerBuildInfoLevels.None)
                return Type + ": " + Message;

            return Message;
        }
    }

    //public class MethodNotFounrBuildInfoItem : BuildInfoItem
    //{
    //    public public MethodNotFounrBuildInfoItem(string method)
    //    {
    //        Type = FormulaCompilerBuildInfoLevels.Error;

    //        Message
    //    }
    //}
}