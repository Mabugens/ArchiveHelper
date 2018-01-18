using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchiveHelper
{
    class ReturnArchive
    {
        public int Id { get; set; }
        public string ArchiveName { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
        public int Copies { get; set; }
        public string Handler { get; set; }
        /// <summary>
        /// 0:无缺失损坏， 1：有损坏无缺失，2：有缺失损坏
        /// </summary>
        public int DamageOrLost { get; set; }
        public string Remark { get; set; }


        public string Returner { get; set; }
    }
}
