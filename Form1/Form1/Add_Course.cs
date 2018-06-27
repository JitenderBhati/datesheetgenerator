using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using CodeBehind;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Add_Course : Form
    {
        static string userName;
        private _context _con;
        List<int> li = new List<int>() { 2, 4, 6, 8, 10 };
        public Add_Course(string name)
        {
            InitializeComponent();
            userName = name;
            _con = new _context();

        }

        int txtPos = 100;
        int lblPos = 80;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            addLabelSubCode(lblPos);
            addTextBoxSubCode(txtPos);
            addLabelSemester(lblPos);
            addComboBox(txtPos);
            txtPos += 52;
            lblPos += 51;
        }
        int a = 2;
        public TextBox addTextBoxSubCode(int txtpos)
        {
            TextBox txtSub = new TextBox();
            panel2.Controls.Add(txtSub);
            txtSub.Name = "txt_course" + a.ToString(); ;
            txtSub.Font = new Font("TIMES NEW ROMAN", 12);
            txtSub.Size = new Size(160, 26);
            txtSub.Location = new Point(13, txtpos);
            txtSub.Margin = new Padding(5);
            a = a + 1;
            return txtSub;
        }
        public Label addLabelSubCode(int lblpos)
        {
            Label lblSub = new Label();
            panel2.Controls.Add(lblSub);
            lblSub.Text = "Course Name";
            lblSub.Font = new Font("Microsoft Sans Serif", 8);
            lblSub.Size = new Size(74, 13);
            lblSub.Location = new Point(13, lblpos);
            //lblSub.Margin = new Padding(3);
            return lblSub;
        }

        public Label addLabelSemester(int lblpos)
        {
            Label lblSem = new Label();
            panel2.Controls.Add(lblSem);
            lblSem.Text = "Number Of Semester";
            lblSem.Font = new Font("Microsoft Sans Serif", 8);
            lblSem.Size = new Size(113, 13);
            lblSem.Location = new Point(252, lblpos);
            //lblSub.Margin = new Padding(3);
            return lblSem;
        }
        int b = 2;
        public ComboBox addComboBox(int txtpos)
        {
            ComboBox combo = new ComboBox();
            panel2.Controls.Add(combo);
            combo.Name = "box_semester" + b.ToString();
            combo.Font = new Font("TIMES NEW ROMAN", 12);
            combo.Size = new Size(121, 27);
            combo.Location = new Point(252, txtpos);
            foreach (var data in li)
            {
                combo.Items.Add(data);
            }
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            b = b + 1;
            return combo;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FirstPage obj = new FirstPage(userName);
            obj.Show();
            this.Close();
        }

        private void Add_Course_Load(object sender, EventArgs e)
        {
            foreach (var datas in li)
            {
                box_semester1.Items.Add(datas);
            }
            var data = _con.Departments.ToList();
            foreach (var datas in data)
            {
                box_dept.Items.Add(datas.name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dept = _con.Departments.SingleOrDefault(c => c.name == box_dept.SelectedItem.ToString());
            for (int i = 1; i < a; i++)
            {
                dynamic txtCourse = "txt_course" + i.ToString();
                dynamic boxSemester = "box_semester" + i.ToString();
                string dataSubject = ((TextBox)panel2.Controls[txtCourse]).Text;
                string dataSubCode = ((ComboBox)panel2.Controls[boxSemester]).SelectedItem.ToString();

                //Checking with Subject Code
                int noOfSem = Int32.Parse(dataSubCode);
                var data = _con.Courses.SingleOrDefault(c => (c.tbl_departmentId == dept.id) && (c.name == dataSubject.ToUpper()) && (c.total_number_of_Semester == noOfSem));
                if (data != null)
                {
                    MessageBox.Show("Course Already Exist!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    var dataCode = new tbl_course
                    {
                        name = dataSubject.ToUpper(),
                        total_number_of_Semester = Convert.ToInt32(dataSubCode),
                        tbl_departmentId = dept.id
                    };
                    _con.Courses.Add(dataCode);
                    _con.SaveChanges();
                }
            }

            if (MessageBox.Show("Saved Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                FirstPage obj = new FirstPage(userName);
                this.Close();
                obj.Show();
            }
        }
    }
}
