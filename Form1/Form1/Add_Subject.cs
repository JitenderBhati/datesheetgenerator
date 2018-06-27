using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBehind;
using System.Windows.Forms;
using System.Data.Entity;

namespace Form1
{
    public partial class Add_Subject : Form
    {
        private _context _con;
        static string userName = "";
        public Add_Subject(string name)
        {
            InitializeComponent();
            _con = new _context();
            userName = name;
           
        }

        private void Add_Subject_Load(object sender, EventArgs e)
        {
            var departments = _con.Departments.ToList();
            if (departments != null)
            {
                foreach (var depart in departments)
                {
                    box_dept.Items.Add(depart.name);
                }
            }

            var type = _con.Type.ToList();
            if (type != null)
            {
                foreach (var typ in type)
                    box_type.Items.Add(typ.name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void box_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            box_course.Items.Clear();
            box_semester.Items.Clear();
            var q = box_dept.SelectedItem.ToString();
            var data = _con.Courses.Include(c => c.department).ToList();
            foreach (var query in data)
            {
                if (query.department.name == q)
                {
                    box_course.Items.Add(query.name);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FirstPage obj = new FirstPage(userName);
            obj.Show();
            this.Close();
        }

        int txtPos = 100;
        int lblPos = 80;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addLabelSubCode(lblPos);
            addTextBoxSubCode(txtPos);
            addLabelSubject(lblPos);
            addTextBoxSubject(txtPos);
            txtPos +=52;
            lblPos +=51;
        }
        int a = 2;
        public TextBox addTextBoxSubject(int txtpos)
        {
            TextBox txtSub = new TextBox();
            panel2.Controls.Add(txtSub);
            txtSub.Name = "txt_subject" + a.ToString(); ;
            txtSub.Font = new Font("TIMES NEW ROMAN", 9);
            txtSub.Size = new Size(254, 22);
            txtSub.Location = new Point(308, txtpos);
            txtSub.Margin = new Padding(5);
            a = a + 1;
            return txtSub;
        }
        public Label addLabelSubject(int lblpos)
        {
            Label lblSub = new Label();
            panel2.Controls.Add(lblSub);
            lblSub.Text = "Subject Name";
            lblSub.Font = new Font("Microsoft Sans Serif", 8);
            lblSub.Size = new Size(74, 13);
            lblSub.Location = new Point(308, lblpos);           
            //lblSub.Margin = new Padding(3);
            return lblSub;
        }
        int b = 2;
        public TextBox addTextBoxSubCode(int txtpos)
        {
            TextBox txt = new TextBox();
            panel2.Controls.Add(txt);
            txt.Name = "txt_subcode" + b;
            txt.Font = new Font("TIMES NEW ROMAN", 9);
            txt.Size = new Size(138, 21);
            txt.Location = new Point(53, txtpos);
            txt.Margin = new Padding(5);
            b = b + 1;
            return txt;
        }
        public Label addLabelSubCode(int lblpos)
        {
            Label lbl = new Label();
            panel2.Controls.Add(lbl);
            lbl.Text = "Subject Code";
            lbl.Font = new Font("Microsoft Sans Serif", 8);
            lbl.Size = new Size(71, 13);
            lbl.Location = new Point(53, lblpos);
            lbl.ForeColor = Color.Black;
            lbl.Margin = new Padding(3);
            return lbl;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var dept = _con.Departments.SingleOrDefault(c => c.name == box_dept.SelectedItem.ToString());
            var course = _con.Courses.SingleOrDefault(c => c.name == box_course.SelectedItem.ToString());
            var type = _con.Type.SingleOrDefault(c => c.name == box_type.SelectedItem.ToString());
            var sem = _con.Semester.SingleOrDefault(c => c.name == box_semester.SelectedItem.ToString());
            for(int i=1; i<a; i++)               
            {
                    dynamic txtSubject = "txt_subject" + i.ToString();
                    dynamic txtSubCode = "txt_subcode" + i.ToString();
                    string dataSubject = ((TextBox)panel2.Controls[txtSubject]).Text;
                    string dataSubCode = ((TextBox)panel2.Controls[txtSubCode]).Text;

                    //Checking with Subject Code

                    var data = new tbl_subject
                    {
                        name = dataSubject,
                        tbl_typeId = type.id,
                        tbl_courseId = course.id,
                        tbl_semesterId = sem.id
                    };
                    _con.Subject.Add(data);
                    _con.SaveChanges();            
               
                              
            }
            if (MessageBox.Show("Subjects Saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                FirstPage obj = new FirstPage(userName);
                obj.Show();
                this.Close();
                
            }
        }

        private void box_course_SelectedIndexChanged(object sender, EventArgs e)
        {
            box_semester.Items.Clear();
            var q = box_course.SelectedItem.ToString();
            var data = _con.Courses.SingleOrDefault(c => c.name == q);
            var no = data.total_number_of_Semester;
            var sem = _con.Semester.ToList();
            for (int i = 1; i <= no; i++)
            {
                foreach (var semester in sem)
                {
                    if (semester.id == i)
                        box_semester.Items.Add(semester.name);
                }
            }
        }
    }
}
