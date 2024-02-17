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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakDilKursu;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from AdminGiris where KullaniciAdi='" + textBox1.Text + "' AND Sifre='" +textBox2.Text +"'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                AnaSayfa frm = new AnaSayfa();
                frm.Show();
                this.Hide();

            }
            else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış!");
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayitOl frm = new KayitOl();
            frm.Show();       
            this.Hide();
            
            
        }
    }
}
