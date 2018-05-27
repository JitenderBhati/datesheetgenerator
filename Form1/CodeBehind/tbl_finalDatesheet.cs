using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBehind
{
   public class tbl_finalDatesheet
    {
        public int id { get; set; }
        public int session { get; set; }
        public string odd_even { get; set; }
        public tbl_type type { get; set; }
        public int tbl_typeId { get; set; }
        public tbl_course course { get; set; }
        public int tbl_courseId { get; set; }
        public tbl_semester semester { get; set; }
        public int tbl_semesterId { get; set; }
        public tbl_subjectDatesheet subjectDatesheet { get; set; }
        public int tbl_subjectDatesheet { get; set; }
    }
}
