using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace BFsharp.VisualStudioExtensions
{
    public partial class VisualizerForm : Form
    {
        public VisualizerForm()
        {
            InitializeComponent();
            ElementHost host = new ElementHost();
            host.Dock = DockStyle.Fill;

            Visualizer visualizer = new Visualizer();
            host.Child = visualizer;

            Controls.Add(host);
        }
    }
}
