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
    public partial class KayitOl : Form
    {
        public KayitOl()
        {
            
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakDilKursu;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            LoginPage frm = new LoginPage();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into AdminGiris values('" + textBox1.Text + "','" + textBox2.Text + "','"+ textBox4.Text+"','"+ textBox3.Text+"')", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Olundu");
            baglanti.Close();
            
        }

        private void KayitOl_Load(object sender, EventArgs e)
        {
            textBox4.Focus();
        }
    }
}
