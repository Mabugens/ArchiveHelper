using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    class LendArchive
    {
        public int Id { get; set; }
        public string ArchiveName { get; set; }
        public Nullable<DateTime> LendDate { get; set; }
        public int Copies { get; set; }

        public string LendReason { get; set; }
        public string LendUnit { get; set; }
        public string Handler { get; set; }
        public string Phone { get; set; }

        public Nullable<DateTime> ExpectedReturnDate { get; set; }

        public string Borrower { get; set; }

        public string ApprovedBy { get; set; }

        public string NeedReturn { get; set; }

        public int ArchId { get; set; }
    }
}
