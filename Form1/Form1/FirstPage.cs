using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class FirstPage : Form
    {
        static string userName;
        public FirstPage(string name)
        {
            InitializeComponent();
            userName = name;
            lbl_names.Text = name;
        }

        private void FirstPage_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPage obj = new MainPage(userName);
            this.Close();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Close();
            obj.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Department obj = new Add_Department(userName);
            obj.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Subject obj = new Add_Subject(userName);
            obj.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Course obj = new Add_Course(userName);
            obj.Show();
            this.Close();                     
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
