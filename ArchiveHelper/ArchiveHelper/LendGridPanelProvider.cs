using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public class LendGridPanelProvider : GridPanelProvider
    {
        public override GridColumnCollection GetColumns()
        {
            LendGridCtrl ctrl = new LendGridCtrl();
            return ctrl.GetGridPanel().Columns;
        }
    }
}
