using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBehind
{
    public class tbl_subjectDatesheet
    {
        public int id { get; set; }
        public tbl_subject subject { get; set; }
        public int tbl_subjectID { get; set; }
        public DateTime date { get; set; }
        public tbl_shift shift { get; set; }
        public int tbl_shiftId { get; set; }
        public tbl_datesheet datesheet { get; set; }
        public int tbl_datesheetId { get; set; }
        public tbl_block block { get; set; }
        public int tbl_blockId { get; set; }
        public int session { get; set; }
        public string odd_even { get; set; }

    }
}
