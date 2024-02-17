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
    public partial class FrmGelirGider : Form
    {
        public FrmGelirGider()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakPansiyon;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(Ucret) as Toplam from MusteriEkle", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                label6.Text = oku["Toplam"].ToString();
            }
            baglanti.Close();

            int personel;
            personel = Convert.ToInt16(textBox1.Text);
            label7.Text = (personel * 20000).ToString();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(Gida+İcecekler+Atistirmaliklar) as toplam from Stoklar",baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                label8.Text = oku2["toplam"].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select sum(Elektrik+Su+İnternet) as toplam from Faturalar", baglanti);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                label9.Text = oku3["toplam"].ToString();
            }
            baglanti.Close();

            int l6 = Convert.ToInt32(label6.Text);
            int l7 = Convert.ToInt32(label7.Text);
            int l8 = Convert.ToInt32(label8.Text);
            int l9 = Convert.ToInt32(label9.Text);

            label11.Text = (l6 - (l7 + l8 + l9)).ToString();
        }
    }
}
