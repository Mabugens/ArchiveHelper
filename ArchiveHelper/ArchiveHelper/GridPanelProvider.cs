using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public abstract class GridPanelProvider
    {
        
        public GridPanelProvider()
        {

        }
        
        public abstract GridColumnCollection GetColumns();
        
    }
}
