using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public class ArchiveGridPanelProvider : GridPanelProvider
    {
        public override GridColumnCollection GetColumns()
        {
            ArchiveGridCtrl ctrl = new ArchiveGridCtrl();
            return ctrl.GetReturnGridPanel().Columns;
        }
    }
}
