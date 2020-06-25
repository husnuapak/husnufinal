using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace haliSahaRezervasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlCon sql = new SqlCon();
        public void DataGridYenile()
        {
            dataGridView2.DataSource = sql.RezervasyonTablo();
        }
        public void gridview()
        {
            DataGridYenile();
        }
        public int SahaFiyat = 0;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.textBox1.Text = dataGridView2.SelectedCells[5].Value.ToString();
            label5.Text = dataGridView2.SelectedCells[1].Value.ToString();
            label7.Text = dataGridView2.SelectedCells[3].Value.ToString()+ " / "+ dataGridView2.SelectedCells[2].Value.ToString();
            label6.Text = dataGridView2.SelectedCells[5].Value.ToString();
            richTextBox1.Text = dataGridView2.SelectedCells[6].Value.ToString();

            button5.Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataGridYenile();

            
            dataGridView2.ClearSelection();
            if (dataGridView2.Rows.Count != 0)
            {
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Selected = true;
                Form3 f3 = new Form3();
                f3.textBox1.Text = dataGridView2.SelectedCells[5].Value.ToString();
                f3.RSahaId = int.Parse(dataGridView2.SelectedCells[0].Value.ToString());
                f3.RTarih = dataGridView2.SelectedCells[2].Value.ToString();
                f3.RSaat = dataGridView2.SelectedCells[3].Value.ToString();
                label5.Text = dataGridView2.SelectedCells[1].Value.ToString();
                label7.Text = dataGridView2.SelectedCells[3].Value.ToString() + " / " + dataGridView2.SelectedCells[2].Value.ToString();
                label6.Text = dataGridView2.SelectedCells[5].Value.ToString();
                richTextBox1.Text = dataGridView2.SelectedCells[6].Value.ToString();

                
            }
            else
            {
                
            }
            button5.Visible = true;
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Form3 f3 = new Form3();
            try
            {
                if (bool.Parse(dataGridView2.SelectedCells[7].Value.ToString())==false) 
                { 
                
                
                f3.textBox1.Text = dataGridView2.SelectedCells[5].Value.ToString();
                f3.RSahaId = int.Parse(dataGridView2.SelectedCells[0].Value.ToString());
                f3.RTarih = dataGridView2.SelectedCells[2].Value.ToString();
                f3.RSaat = dataGridView2.SelectedCells[3].Value.ToString();
                f3.ShowDialog();
                dataGridView2.ClearSelection();
                label5.Text =  "";
                label7.Text =  "";
                
                label6.Text = "";
                richTextBox1.Text = "";
                button5.Visible = false;
                    DataGridYenile();
                    dataGridView2.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Seçtiğiniz rezervasyon ödenmiş.");
                    dataGridView2.ClearSelection();
                }
            }
            catch
            {
                MessageBox.Show("Ödeme Yapmak İçin Rezervasyon Seçiniz.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
