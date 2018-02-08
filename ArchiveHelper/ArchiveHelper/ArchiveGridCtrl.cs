using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.SuperGrid;

namespace ArchiveHelper
{
    public partial class ArchiveGridCtrl : UserControl
    {
        public ArchiveGridCtrl()
        {
            InitializeComponent();
        }

        public GridPanel GetReturnGridPanel()
        {
            return this.ArchiveGrid.PrimaryGrid;
        }
    }
}
