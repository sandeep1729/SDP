using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Login
{
    public partial class Unhide : Form
    {
        public Unhide()
        {
            InitializeComponent();
        }

        private void Unhide_Load(object sender, EventArgs e)
        {
            button3.Enabled = true;
            for (int i = 0; i < 256; i++)
            {
                char c = Convert.ToChar(i);
                a[i] = c.ToString();
            }
            for (int i = 0; i < 256; i++)
            {
                cl[i] = Color.FromArgb(255, 254, 254, i);

            }

        }
        private string[] a = new string[256];
        static private Color[] cl = new Color[256];
        static int cp;
        public Bitmap objBmpImage = new Bitmap(1, 1); string decript;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            openFileDialog1.ShowDialog();
            try
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("select the image to decrypt");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string dect = dec(richTextBox1.Text);
                richTextBox2.Text = dect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private const string cryptoKey = "cryptoKey";
        byte[] IV = new byte[8] { 240, 5, 68, 7, 0, 98, 6, 4 };
        public string dec (string s)
        {
            byte[] buffer =Convert.FromBase64String(s);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            des.Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

            des.IV = IV;

            string res = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            return res;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        string temp1 = "";
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                button3.Enabled = false;
                objBmpImage = new Bitmap(pictureBox1.Image);
            }
            catch (Exception ex)
            {
                MessageBox.Show("no image to decrypt");
            }
                cp = 0;
            richTextBox1.Text = "";
            int s11 = 11;
            int s12 = 34;

            int th = objBmpImage.Height;
            th = th - 30;
            int thd = th / 7;

            for (int k = 0; k < (thd * 240); k++)
            {

                if (objBmpImage.Width <= s11)
                {
                    break;
                }



                if (cp == 240)
                {
                    s11 = 11;
                    s12 = s12 + 7;
                    cp = 0;
                }
                if (objBmpImage.Height <= s12)
                {
                    break;
                }

                Color c11 = objBmpImage.GetPixel(s11, s12);
               
                for (int j = 0; j < 256; j++)
                {
                    if (c11.ToArgb() == cl[j].ToArgb())
                    {
                        temp1 = temp1 + a[j];
                        //richTextBox1.Rtf = a[j];
                        //    richTextBox1.SelectedText = a[j];
                        cp = cp + 1;
                    }

                }


                s11 = s11 + 8;
            }
            //string[] lines = richTextBox1.Lines;

            decript = temp1;
            richTextBox1.Text = decript; 
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
