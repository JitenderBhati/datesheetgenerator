using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeBehind
{
    public class _context: DbContext
    {
        public _context() : base("name=DefaultConnection")
        {
        }
        public DbSet<tbl_users> Users { get; set; }
        public DbSet<tbl_department> Departments { get; set; }
        public DbSet<tbl_course> Courses { get; set; }
        public DbSet<tbl_semester> Semester { get; set; }     
        public DbSet<tbl_subject> Subject { get; set; }
        public DbSet<tbl_datesheet> DateSheet { get; set; }
        public DbSet<tbl_block> Block { get; set; }
        public DbSet<tbl_type> Type { get; set; }
        public DbSet<tbl_shift> Shift { get; set; }
        public DbSet<tbl_subjectDatesheet> SubjectDateSheet { get; set; }
        public DbSet<tbl_finalDatesheet> FinalDatesheet { get; set; }
        // public DbSet<tbl_BlockSet> BlockSets { get; set; }


    }
}
