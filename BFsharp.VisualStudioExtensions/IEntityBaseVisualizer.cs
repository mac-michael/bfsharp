using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using BFsharp;
using BFsharp.VisualStudioExtensions;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace BFsharp.VisualStudioExtensions
{
    public class IEntityBaseVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            //objectProvider.
        }
    }

    public class EntityExtensionsDebugView
    {
        
    }

    public class Entity
    {
        public string Name { get; set; }
    }
}
