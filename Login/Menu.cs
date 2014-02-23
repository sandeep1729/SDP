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
    public partial class Menu : Form
    {
        public int i = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                Hide ob = new Hide();
                ob.MdiParent = this;
                ob.Show();
                
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Are You Sure You want to close ", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            { }
            //Unhide ob = new Unhide();
            //ob.MdiParent = this;
            //ob.Show();
        }

        private void unhideToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Unhide ob = new Unhide();
            ob.MdiParent = this;
            ob.Show();
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            help ob = new help();
            ob.MdiParent = this;
            ob.Show();
        }
    }
}
