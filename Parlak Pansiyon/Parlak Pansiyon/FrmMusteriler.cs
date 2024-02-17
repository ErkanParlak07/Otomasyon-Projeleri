using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Parlak_Pansiyon
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakPansiyon;Integrated Security=True");

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
                   
        }
        private void Listele()
        {
            this.musteriEkleTableAdapter.Fill(this.parlakPansiyonDataSet.MusteriEkle);
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = TxtAdi.Text;
            string t2 = TxtSoyadi.Text;
            string t3 = comboBox1.Text;
            string t4 = MskTxtTelefon.Text;
            string t5 = TxtMail.Text;
            string t6 = MskTxtTc.Text;
            string t7 = TxtOdaNumarasi.Text;
            string t8 = TxtUcret.Text;
            string t9 = DtpGirisTarihi.Value.ToString("yyyy-MM-dd");
            string t10 = DtpCikisTarihi.Value.ToString("yyyy-MM-dd");

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update MusteriEkle set Adi='" + t1 + "',Soyadi='" + t2 + "',Cinsiyet='" + t3 + "',Telefon='" + t4 + "',Mail='" + t5 + "',TC='" + t6 + "',OdaNo='" + t7 + "',Ucret='" + t8 + "',GirisTarihi='" + t9 + "',CikisTarihi='" + t10 + "' where Musteriid='" + id + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtAdi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            TxtSoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            MskTxtTelefon.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            TxtMail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            MskTxtTc.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            TxtOdaNumarasi.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            TxtUcret.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            DtpGirisTarihi.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            DtpCikisTarihi.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TxtOdaNumarasi.Text == "101")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda101",baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
            if (TxtOdaNumarasi.Text == "102")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda102", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
            if (TxtOdaNumarasi.Text == "103")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda103", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
            if (TxtOdaNumarasi.Text == "104")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda104", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
            if (TxtOdaNumarasi.Text == "105")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda105", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
            if (TxtOdaNumarasi.Text == "106")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda106", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
            if (TxtOdaNumarasi.Text == "107")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda107", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
            if (TxtOdaNumarasi.Text == "108")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda108", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }
            if (TxtOdaNumarasi.Text == "109")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from Oda109", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Listele();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TxtAdi.Text = "";
            TxtSoyadi.Text = "";
            TxtMail.Text = "";
            TxtOdaNumarasi.Text = "";
            TxtUcret.Text = "";
            MskTxtTc.Text = "";
            MskTxtTelefon.Text = "";
            comboBox1.Text = "";
            DtpGirisTarihi.Text = "";
            DtpCikisTarihi.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string srg = TxtAra.Text;

            string sorgu = "Select * from MusteriEkle where Adi Like '%" + srg + "%'";

            SqlDataAdapter adap = new SqlDataAdapter(sorgu, baglanti);

            DataSet ds = new DataSet();

            adap.Fill(ds, "MusteriEkle");

            this.dataGridView1.DataSource = ds.Tables[0];

            baglanti.Close();

        }
    }
}
