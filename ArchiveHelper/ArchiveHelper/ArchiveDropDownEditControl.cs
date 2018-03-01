using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public class ArchiveDropDownEditControl : GridComboTreeEditControl
    {
        public ArchiveDropDownEditControl(IEnumerable orderArray)
        {
            DataSource = orderArray;
        }
    }
}
