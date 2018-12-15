using System.Windows;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace BFsharp.VisualStudioExtensions
{
    public class IEntityExtensionsVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            MessageBox.Show(objectProvider.GetObject().ToString());
        }
    }
}