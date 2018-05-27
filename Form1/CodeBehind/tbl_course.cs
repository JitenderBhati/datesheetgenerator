using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBehind
{
    public class tbl_course
    {
        public int id { get; set; }
        public string name { get; set; }
        public tbl_department department { get; set; }
        public int tbl_departmentId { get; set; }
        public int total_number_of_Semester { get; set; }
        public tbl_semester semester { get; set; }
    }
}
