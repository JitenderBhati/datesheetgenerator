using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBehind
{
    public class tbl_capacityCalc
    {
        public int id { get; set; }
        public int capacity { get; set; }
        public DateTime date { get; set; }
        public tbl_shift shift { get; set; }
        public int tbl_shiftId { get; set; }
        public int year { get; set; }
        public tbl_block block { get; set; }
        public int tbl_blockId { get; set; }
    }
}
