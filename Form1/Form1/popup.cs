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
    public partial class popup : Form
    {
        public popup(int data)
        {
            InitializeComponent();
            lbl_set.Text = data.ToString();
            this.txt_set.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txt_set.Text) <= Convert.ToInt32(lbl_set.Text))
            {
                this.Hide();
                MainPage.getSetData = txt_set.Text;
                MainPage obj = new MainPage("Test");
                obj.Enabled = true;
            }
            else
                txt_set.Text = " ";
        }
       
    }
}
