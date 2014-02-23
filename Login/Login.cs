using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   Menu obj=new Menu();
            
            if (textBox1.Text == "ADMIN-BQDC5BS-ADMIN")
            {
                obj.Show();
                this.Hide();
                         
            }
            else
            {
                MessageBox.Show("Wrong Key");
                MessageBox.Show("Re enter the key");
            }   
        }
    }
}
