using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public class ReturnGridPanelProvider : GridPanelProvider
    {
        public override GridColumnCollection GetColumns()
        {
            ReturnGridCtrl ctrl = new ReturnGridCtrl();
            return ctrl.GetReturnGridPanel().Columns;
        }
    }
}
