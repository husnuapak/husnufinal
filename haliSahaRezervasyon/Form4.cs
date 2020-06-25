using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace haliSahaRezervasyon
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text!=null&&richTextBox1.Text!="")
            {
                richTextBox1.Text = "Yok";
                this.Close();
            }
            else 
            {
                if(MessageBox.Show("Not girmek istemediğinize emin misiniz.","Uyarı!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes) 
                {
                    this.Close();
                }

            }
        }
    }
}
