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
    public partial class Hide : Form
    {
        public Hide()
        {
            InitializeComponent();
        }
        Menu obj = new Menu();
        Control x;

        public Bitmap objBmpImage = new Bitmap(1, 1);
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            obj.i = 1;
            
            
        }
        public string[] a = new string[256];

        public Color[] cl = new Color[256];
        private void Hide_Load(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            try
            {
                richTextBox2.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select or enter some text");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string encdata;
            encdata = enc(richTextBox2.Text);
            richTextBox1.Text = encdata;
        }

    private const string cryptoKey = "cryptoKey";
        byte[] IV = new byte[8] { 240, 5, 68, 7, 0, 98, 6, 4 };
        public string enc(string s)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(s);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            des.Key =md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

            des.IV = IV;

            string res=Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer,0,buffer.Length));
            return res;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            try
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("select a location to save");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateBitmapImage(richTextBox1.Text);
            pictureBox1.Image = objBmpImage;
        }
        int cp;
        private Bitmap CreateBitmapImage(string sImageText)
        {
            string c;
            cp = 0;
            c = sImageText.ToString();
            int totl = c.Length;
            int t2 = totl / 50;
            int intWidth = 0;
            int intHeight = 0;

            // Create the Font object for the image text drawing.
            Font objFont = new Font("Arial",40, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);

            // Create a graphics object to measure the text's width and height.
            Graphics objGraphics = Graphics.FromImage(objBmpImage);

            // This is where the bitmap size is determined.
            intWidth = (int)objGraphics.MeasureString(sImageText, objFont).Width;
            intHeight = (int)objGraphics.MeasureString(sImageText, objFont).Width;
            //intHeight = intHeight / 50;
            // intWidth = (int)objGraphics.MeasureString(c, objFont).Width / 2;
            intWidth = 2000;
            intHeight = 6000;
            ////if (t2 == 0)
            ////{
            ////    t2 = 0;

            ////    intHeight = 40 + (t2 * 7);
            ////}
            ////else
            ////{
            ////    t2 = 1;

            ////    intHeight = 40 + (t2 * 7);
            ////}
            // Create the bmpImage again with the correct size for the text and font.
            //objBmpImage.MakeTransparent(Color.DarkMagenta);
            objBmpImage = new Bitmap(objBmpImage, new Size(intWidth, intHeight));

            // Add the colors to the new bitmap.
            objGraphics = Graphics.FromImage(objBmpImage);

            // Set Background color
            //objGraphics.Clear(Color.FromArgb(255,0,0,0));

            objGraphics.Clear(Color.SkyBlue);
            Point objPoint = new Point(0, 0);
            int r1, g1, b1, a1;

            string cyp = sImageText;

            for (int i = 0; i < cyp.Length; i++)
            {
                string temp = "";
                temp = cyp.Substring(i, 1);

                for (int j = 0; j < 256; j++)
                {
                    if (temp == a[j])
                    {
                        Color FontColor = cl[j];
                        SolidBrush objBrushForeColor = new SolidBrush(FontColor);
                        //draw the text 
                        objPoint.X += 8;
                        a1 = FontColor.A;
                        r1 = FontColor.R;
                        g1 = FontColor.G;
                        b1 = FontColor.B;

                        objGraphics.DrawString(".", objFont, new SolidBrush(Color.FromArgb(a1, r1, g1, b1)), objPoint);
                        cp = cp + 1;

                    }
                }

                if (cp == 240)
                {
                    objPoint.Y += 7;
                    objPoint.X = 0;
                    cp = 0;
                }
            }

            return (objBmpImage);



        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
