using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ParlakDilKursu
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakDilKursu;Integrated Security=True");
        private void verileriGoster()
        {
            this.ogrenciKayitTableAdapter4.Fill(this.parlakDilKursuDataSet3.OgrenciKayit);

        }

        private void Kayit_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet3.OgrenciKayit' table. You can move, or remove it, as needed.
            this.ogrenciKayitTableAdapter4.Fill(this.parlakDilKursuDataSet3.OgrenciKayit);
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet2.OgrenciKayit' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet1.OgrenciKayit' table. You can move, or remove it, as needed.
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            TxtResim.Text=openFileDialog1.FileName;

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if(TxtAdSoyad.Text=="" || TxtTelefon.Text==""||  richTextBox1.Text == "" || comboBox1.Text == "" || TxtResim.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into OgrenciKayit values('" +TxtAdSoyad.Text + "','" + comboBox1.Text + "','" + TxtResim.Text + "','" + richTextBox1.Text + "','" + TxtTelefon.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Öğrenci Başarıyla Eklendi");
                verileriGoster();
                baglanti.Close();
            }
           
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TxtAdSoyad.Text = "";
            TxtResim.Text = "";
            TxtTelefon.Text = "";
            richTextBox1.Text = "";        
            comboBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Hide();
        }
    }
}
