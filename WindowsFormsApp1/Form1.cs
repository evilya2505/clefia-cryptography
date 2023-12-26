using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Голубика";
            textBox2.Text = "ffeeddccbbaa99887766554433221100";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            textBox4.Visible = false;

            string plainText = textBox1.Text;
            string key = textBox2.Text;
            byte[][] result = CLEFIACipherTest.CLEFIACipher(key, plainText, 18);
            string stringResult = "";
            for (int i = 0; i < result.Length; i++)
            {
                stringResult += BitConverter.ToString(result[i]).Replace("-", "").ToLower() + " ";
            }
            textBox3.Text = stringResult;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cipherText = textBox1.Text;
            string key = textBox2.Text;
            byte[][] result = CLEFIACipherTest.InverseCLEFIACipher(key, cipherText, 18);
            string stringResult = "";
            string stringResultForFunc = "";
            for (int i = 0; i < result.Length; i++)
            {
                stringResult += BitConverter.ToString(result[i]).Replace("-", "").ToLower() + " ";
                stringResultForFunc += BitConverter.ToString(result[i]).Replace("-", "").ToLower();
            }
            textBox3.Text = stringResult;

            label8.Visible = true;
            textBox4.Visible = true;

            textBox4.Text = CLEFIACipherTest.HexStringToString(stringResultForFunc);
        }
    }
}
