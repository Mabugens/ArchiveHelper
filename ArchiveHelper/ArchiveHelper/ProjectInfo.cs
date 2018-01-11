using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public class ProjectInfo
    {
        public ProjectInfo()
        {
            //ArchiveInfoList = new List<ArchiveInfo>();
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int IsFreeze { get; set; }

        public List<ArchiveInfo> ArchiveInfoList;
    }
}
