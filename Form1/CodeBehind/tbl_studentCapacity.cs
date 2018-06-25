using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBehind
{
    public class tbl_studentCapacity
    {
        public int id { get; set; }

        public int capacity { get; set; }

        public tbl_semester studentCapacity { get; set; }
        public int tbl_semesterId { get; set; }

        public tbl_course course { get; set; }
        public int tbl_courseId { get; set; }

    }
}
