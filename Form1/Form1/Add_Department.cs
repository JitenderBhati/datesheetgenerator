using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeBehind;

namespace Form1
{
    public partial class Add_Department : Form
    {
        private _context _con;
        static string userName = "";
        public Add_Department(string name)
        {
            InitializeComponent();
            userName = name;
            _con = new _context();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = _con.Departments.SingleOrDefault(c => c.name == txt_department.Text.ToUpper());
            if (data == null)
            {
                var datas = new tbl_department
                {
                    name = txt_department.Text.ToUpper()
                };
                _con.Departments.Add(datas);
                _con.SaveChanges();
                MessageBox.Show("Saved Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Department Already Exist!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (MessageBox.Show("Want to Add more department?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Add_Department obj = new Add_Department(userName);
                obj.Show();
                this.Close();
            }
            else
            {
                FirstPage obj = new FirstPage(userName);
                obj.Show();
                this.Close();             
            }
        }

        private void Add_Department_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FirstPage obj = new FirstPage(userName);
            this.Close();
            obj.Show();
        }
    }
}
