using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    class GridCellDropDownEditControl : GridComboTreeEditControl
    {
        public GridCellDropDownEditControl(IEnumerable orderArray)
        {
            DataSource = orderArray;
        }
    }
}
