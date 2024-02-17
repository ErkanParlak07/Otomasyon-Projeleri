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

namespace ParlakDilKursu
{
    public partial class YeniPuan : Form
    {
        public YeniPuan()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakDilKursu;Integrated Security=True");

        private void YeniPuan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet12.OgrenciKayit' table. You can move, or remove it, as needed.
            this.ogrenciKayitTableAdapter.Fill(this.parlakDilKursuDataSet12.OgrenciKayit);
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet11.Puan' table. You can move, or remove it, as needed.
            this.puanTableAdapter.Fill(this.parlakDilKursuDataSet11.Puan);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TxtOgrenciid.Text == "" || TxtPuan.Text == "" || richTextBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Puan values('" + TxtOgrenciid.Text + "','" + TxtPuan.Text + "','" + comboBox1.Text + "','" + richTextBox1.Text+ "')", baglanti);
                komut.ExecuteNonQuery();
                this.puanTableAdapter.Fill(this.parlakDilKursuDataSet11.Puan);
                baglanti.Close();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TxtPuan.Text = "";
            TxtOgrenciid.Text = "";
            comboBox1.Text = "";
            richTextBox1.Text = "";
        }
    }
}
