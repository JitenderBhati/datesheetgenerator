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
    public partial class Form1 : Form
    {
        private _context _con;
      
        public Form1()
        {
            InitializeComponent();
            _con = new _context();
        }     


        private void button1_Click(object sender, EventArgs e)
        {
            var data = _con.Users.SingleOrDefault(c => c.uname.Equals(txtbox_uname.Text)&&(c.password.Equals(txtbox_password.Text)));
            if(data==null)
            {
                MessageBox.Show("Username or password is incorrect");
                txtbox_uname.Text = null;
                txtbox_password.Text = null;
            }
            else if(txtbox_uname.Text == null || txtbox_password.Text == null)
            {
                MessageBox.Show("Field must be filled");
                txtbox_uname.Text = null;
                txtbox_password.Text = null;
            }
            else
            {
                //MessageBox.Show("Login Successfully");                
                FirstPage obj = new FirstPage(data.uname);
                this.Hide();
                obj.Show();
                
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
