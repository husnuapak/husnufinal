using haliSahaRezervasyon.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using haliSahaRezervasyon.Entity;
using System.Deployment.Application;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace haliSahaRezervasyon
{
    public partial class Form1 : Form
    {
        SqlCon sql = new SqlCon();

        public Form1()
        {
            InitializeComponent();
        }
        Context c = new Context();
        private void Form1_Load(object sender, EventArgs e)
        {
            c.Database.CreateIfNotExists();
            
            DataGridYenile();
             
             BindingSource bindingSource1 = new BindingSource();
             BindingSource bindingSource2 = new BindingSource();
          /*   bindingSource1.Add(new Saatler("08:00 - 09:00"));
             bindingSource1.Add(new Saatler("09:00 - 10:00"));
             bindingSource1.Add(new Saatler("10:00 - 11:00"));
             bindingSource1.Add(new Saatler("11:00 - 12:00"));
             bindingSource1.Add(new Saatler("12:00 - 13:00"));
             bindingSource1.Add(new Saatler("13:00 - 14:00"));
             bindingSource1.Add(new Saatler("14:00 - 15:00"));
             bindingSource1.Add(new Saatler("15:00 - 16:00"));
             bindingSource1.Add(new Saatler("16:00 - 17:00"));
             bindingSource1.Add(new Saatler("17:00 - 18:00"));
             bindingSource1.Add(new Saatler("18:00 - 19:00"));
             bindingSource1.Add(new Saatler("19:00 - 20:00"));
             bindingSource1.Add(new Saatler("20:00 - 21:00"));
             bindingSource1.Add(new Saatler("21:00 - 22:00"));
             bindingSource1.Add(new Saatler("22:00 - 23:00"));
             bindingSource1.Add(new Saatler("23:00 - 24:00"));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 01)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 02)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 03)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 04)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 05)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 06)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 07)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 08)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 09)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 10)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 11)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 12)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 13)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 14)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 15)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 16)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 17)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 18)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 19)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 20)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 21)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 22)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 23)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 24)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 25)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 26)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 27)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 28)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 29)));
            bindingSource2.Add(new Tarihler(new DateTime(2020, 06, 30)));*/

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Saat";
            column.Name = "Saat";
            column.Width = dataGridView4.Width;
            dataGridView4.Columns.Add(column);

            DataGridViewColumn column1 = new DataGridViewTextBoxColumn();
            column1.DataPropertyName = "Tarih";
            column1.Name = "Tarih";
            column1.Width = dataGridView3.Width;
            dataGridView3.Columns.Add(column1);

            dataGridView4.ReadOnly = true;
            dataGridView4.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView4.DataSource = bindingSource1;
            dataGridView3.DataSource = bindingSource2;

            dataGridView1.ClearSelection();
            dataGridView2.ClearSelection();
            dataGridView3.ClearSelection();
            dataGridView4.ClearSelection();

        }
        public void DataGridYenile()
        {
            dataGridView1.DataSource = sql.TabloyuGetir1();
            dataGridView2.DataSource = sql.TabloyuGetir(true);
        }
        string saat,tarih,SahaId;
        private void button1_Click(object sender, EventArgs e)
        {
            
            Sahalar saha = new Sahalar();
            int strToplam = dataGridView2.Rows.Count;
            if(textBox3.Text!=null&&textBox3.Text!=""&& textBox1.Text != null && textBox1.Text != ""&& textBox2.Text != null && textBox2.Text != ""&& richTextBox1.Text != null && richTextBox1.Text != "") {
            for (int i = 0; i < strToplam; i++)
            {
               if(dataGridView2.Rows[i].Cells[1].Value.ToString()!=textBox3.Text)
                {
                    //MessageBox.Show(dataGridView2.Rows[i].Cells[1].Value.ToString());

                    saha.SahaIsim = textBox3.Text;
                    saha.Adres = richTextBox1.Text;
                    saha.Fiyat = int.Parse(textBox2.Text);
                    saha.SahaKisi = int.Parse(textBox1.Text);
                    saha.SahaDurum = true;
                    c.Sahalars.Add(saha);
                    c.SaveChanges();
                    DataGridYenile();
                    textBox3.Text = "";
                    textBox1.Text = "";
                    richTextBox1.Text = "";
                    textBox2.Text = "";
                    textBox2.Text = "";
                    dataGridView1.ClearSelection();
                    dataGridView2.ClearSelection();
                    break;
                }
                if(i==(strToplam-1))
                {
                    MessageBox.Show("Farklı kayıt giriniz.");
                    textBox3.Text = "";
                    textBox1.Text = "";
                    richTextBox1.Text = "";
                    textBox2.Text = "";
                    textBox2.Text = "";
                }
            }
            }
            else
            {
                MessageBox.Show("Gerekli bilgileri doldurunuz!");
            }
            /*
            saha.SahaIsim = "Oktay Duran Halı Saha";
            saha.Fiyat = 750;
            saha.Adres = "Beşyol, İnönü Caddesi , Cami Sokak 1-9, 34295 Küçükçekmece/İstanbul";
            c.Sahalars.Add(saha);
            c.SaveChanges();*/
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows) 
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
               // bool durum = Convert.ToBoolean(drow.Cells[4].Value);
                sql.SahaDurumGuncelle(numara, false);
                DataGridYenile();
            }
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show( dataGridView4.SelectedCells[0].RowIndex.ToString());

            
            int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
            string saatKontrol = selectedRow.Cells[0].Value.ToString();
            Boolean check = sql.SaatTarihKontrol(int.Parse(sahaidKontrol),tarihKontrol,saatKontrol);

            if (check)
            {
                MessageBox.Show("Bu saatler arası başka bir rezervasyon vardır. ");
            }
            else
            {
                saat = dataGridView4.SelectedCells[0].RowIndex.ToString();
                button5.Visible = true;

                button3.Visible = true;
            }
            /*
            string[] holdindex = new string[dataGridView4.Rows.Count];
            int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
            string a = selectedRow.Cells[0].Value.ToString();
            for (int i = 0; i < holdindex.Length; i++)
            {
                holdindex[i] = dataGridView4.Rows[i].Cells[0].Value.ToString();
                  MessageBox.Show(holdindex[i]+a);
            }
            
            for (int i = 0; i < holdindex.Length; i++)
            {
                if (holdindex[i] == a) 
                {
                    MessageBox.Show(holdindex[i]+a);
                    MessageBox.Show("Bu saatler arası başka bir rezervasyon vardır. ");
                }

            }
            */
            
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        public string sahaidKontrol;
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            SahaId = dataGridView2.SelectedCells[0].RowIndex.ToString();
            label5.Visible = true;

            int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];

            sahaidKontrol = selectedRow.Cells[0].Value.ToString();

            dataGridView3.Visible = true;
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(!Char.IsDigit(ch)&& ch!=8)
            {
                e.Handled = true;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int numara = Convert.ToInt32(drow.Cells[0].Value);
                //bool durum = Convert.ToBoolean(drow.Cells[4].Value);
                sql.SahaDurumGuncelle(numara, true);
                DataGridYenile();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Rezervasyon rzv = new Rezervasyon();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            button5.Visible = false;
            rzv.Notes = f4.richTextBox1.Text;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // Form1 f1 = new Form1();
            //f1.Visible = false;
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int satirs = dataGridView4.Rows.Count;
            for (int i = 0; i < satirs; i++)
            {
                MessageBox.Show(dataGridView4.Rows[i].Cells[0].Value.ToString()); 
            }

        }
        public string tarihKontrol;

        private void button6_Click_1(object sender, EventArgs e)
        {
            
            Form2 f2 = new Form2();
            f2.Visible = true;
        }

        private void RezervasyonYap_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];
            
            tarihKontrol = selectedRow.Cells[0].Value.ToString();


            tarih = dataGridView3.SelectedCells[0].RowIndex.ToString();
            
          
            label6.Visible=true;
            dataGridView4.Visible = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            string s = "";
            string t = "";
            string i = "";
            int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
            string saatKontrol = selectedRow.Cells[0].Value.ToString();
            Boolean check = sql.SaatTarihKontrol(int.Parse(sahaidKontrol), tarihKontrol, saatKontrol);

            if (check)
            {
                MessageBox.Show("Bu saatler arası başka bir rezervasyon var. ");
                MessageBox.Show("Rezervasyonunuz yapılmadı.");
                label5.Visible = false;
                label6.Visible = false;
                dataGridView3.Visible = false;
                dataGridView4.Visible = false;
                button3.Visible = false;
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();
                dataGridView4.ClearSelection();
            }
            else { 
            try { 
             s = dataGridView4.Rows[int.Parse(saat)].Cells["Saat"].Value.ToString();
             t = dataGridView3.Rows[int.Parse(tarih)].Cells["Tarih"].Value.ToString();
             i =  dataGridView2.Rows[int.Parse(SahaId)].Cells["SahaId"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Değerler null olamaz");

            }
             Rezervasyon hsrez = new Rezervasyon();
             if(s==null|t==null|i==null && s==""|t==""|i=="")
            {
                MessageBox.Show("Lütfen seçim yaptığınızdan emin olun.");
                    MessageBox.Show("Rezervasyonunuz yapılmadı.");

                }
                else {
                hsrez.RezervasyonSaat = dataGridView4.Rows[int.Parse(saat)].Cells["Saat"].Value.ToString();
             string v = dataGridView3.Rows[int.Parse(tarih)].Cells["Tarih"].Value.ToString();
                hsrez.Tarih = Convert.ToDateTime(v);
                hsrez.SahaId = int.Parse(dataGridView2.Rows[int.Parse(SahaId)].Cells["SahaId"].Value.ToString());
                hsrez.Notes = f4.richTextBox1.Text;
                c.Rezervasyons.Add(hsrez);
                c.SaveChanges();
                label5.Visible = false;
                label6.Visible = false;
                dataGridView3.Visible = false;
                dataGridView4.Visible = false;
                button3.Visible = false;
                dataGridView1.ClearSelection();
                dataGridView2.ClearSelection();
                dataGridView3.ClearSelection();
                dataGridView4.ClearSelection();
                Form1 f1 = new Form1();
                f1.Visible = false;
                Form2 f2 = new Form2();
                f2.Visible = true;
                
                
            }

            }

        }
    }
}
