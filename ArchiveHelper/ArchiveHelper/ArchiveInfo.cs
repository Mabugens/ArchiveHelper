using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    public class ArchiveInfo
    {
        public bool HasLend { get; set; }

        public int Id { get; set; }
        public string ArchiveName { get; set; }
        public string ArchType { get; set; }
        public Nullable<DateTime> ArchDate { get; set; }
        public string DispatchNum { get; set; }
        public int Copies { get; set; }
        public int Remaining { get; set; }
        public string StorageLocation { get; set; }
        public string Handler { get; set; }

        public int ProjectId { get; set; }

        public ProjectInfo Project { get; set; }

        public Nullable<DateTime> RegisterDate { get; set; }

        public string Remark { get; set; }

    }
}
