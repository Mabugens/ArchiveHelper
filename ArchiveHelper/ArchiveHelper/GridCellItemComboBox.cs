using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    internal class GridCellItemComboBox : GridComboBoxExEditControl
    {
        public GridCellItemComboBox(IEnumerable orderArray)
        {
            DataSource = orderArray;
        }
    }
}
