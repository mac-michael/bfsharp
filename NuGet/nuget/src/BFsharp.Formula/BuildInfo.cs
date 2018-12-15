using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BFsharp.Formula
{
    public class BuildInfo
    {
        public BuildInfo()
        {
            Level = FormulaCompilerBuildInfoLevels.All;
#if DEBUG
            DebugTrace = true;
#endif
        }

        private List<BuildInfoItem> _all;
        public List<BuildInfoItem> All
        {
            get
            {
                if (_all == null)
                    _all = new List<BuildInfoItem>();

                return _all;
            }
        }

        public IEnumerable<BuildInfoItem> Errors
        {
            get
            {
                return _all.Where(b =>
                                  (b.Type & FormulaCompilerBuildInfoLevels.Error) ==
                                  FormulaCompilerBuildInfoLevels.Error);
            }
        }

        public FormulaCompilerBuildInfoLevels Level { get; set; }
        public bool DebugTrace { get; set; }

        public void Log(string message, FormulaCompilerBuildInfoLevels type)
        {
            if ((Level & type) == type)
                LogInternal(message, type);
        }

        private void LogInternal(string message, FormulaCompilerBuildInfoLevels level)
        {
            var buildInfoItem = new BuildInfoItem(message, level);
            All.Add( buildInfoItem);

            if (DebugTrace)
                Debug.WriteLine(buildInfoItem);
        }

        public void Log(string message)
        {
            LogInternal(message, FormulaCompilerBuildInfoLevels.None);
        }

        public void Clear()
        {
            All.Clear();
        }

        public override string ToString()
        {
            return Message;
        }

        public string Message
        {
            get
            {
                var b = new StringBuilder();

                foreach (var item in All)
                    b.AppendLine(item.ToString());

                return b.ToString();
            }
        }
    }
}