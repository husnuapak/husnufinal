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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Form2 f2 = new Form2();
        SqlCon sql = new SqlCon();
        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        public int RSahaId=0;
        public string RTarih, RSaat;
        private void button5_Click(object sender, EventArgs e)
        {
            int toplamMiktar = int.Parse(textBox1.Text);
            int odeme = int.Parse(textBox2.Text);
            if (textBox2.Text!=""||textBox2.Text!=null) { 
            if(radioButton1.Checked || radioButton2.Checked)
            { 
            if(toplamMiktar<=odeme)
            {
                MessageBox.Show("Ödeme Gerçekleşmiştir.");
                if(toplamMiktar<odeme && radioButton1.Checked)
                {
                    MessageBox.Show("Para üstü : "+(odeme-toplamMiktar));
                    

                        }
                        sql.PayCheckUpdate(RTarih,RSaat,RSahaId,true);
                        f2.gridview();
                        this.Close();
            }
            else
            {
                MessageBox.Show("Yetersiz bakiye...");
            }
            }
            else
            {
                MessageBox.Show("Lütfen Ödeme Yönetimini Seçiniz.");
            }
            }
            else
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            radioButton1.PerformClick();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            radioButton2.PerformClick();

        }
    }
}
