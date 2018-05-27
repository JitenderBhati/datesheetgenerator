using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBehind
{
    public class tbl_subject
    {
        public int id { get; set; }
        public string name { get; set; }
        public tbl_course course { get; set; }
        public int tbl_courseId { get; set; }        
        public tbl_semester semester { get; set; }
        public int tbl_semesterId { get; set; }
        public tbl_type Type { get; set; }
        public int tbl_typeId { get; set; }
    }
}
