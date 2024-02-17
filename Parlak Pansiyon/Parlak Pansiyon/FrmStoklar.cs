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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakPansiyon;Integrated Security=True");

        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parlakPansiyonDataSet2.Faturalar' table. You can move, or remove it, as needed.
            this.faturalarTableAdapter.Fill(this.parlakPansiyonDataSet2.Faturalar);
            // TODO: This line of code loads data into the 'parlakPansiyonDataSet1.Stoklar' table. You can move, or remove it, as needed.
            this.stoklarTableAdapter.Fill(this.parlakPansiyonDataSet1.Stoklar);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = textBox1.Text;
            string t2 = textBox2.Text;
            string t3 = textBox3.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Stoklar (Gida,İcecekler,Atistirmaliklar) values('" + t1 + "','" + t2 + "','" + t3 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            this.stoklarTableAdapter.Fill(this.parlakPansiyonDataSet1.Stoklar);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t4 = textBox4.Text;
            string t5 = textBox5.Text;
            string t6 = textBox6.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Stoklar (Elektrik,Su,İnternet) values('" + t6 + "','" + t5 + "','" + t4 + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            this.faturalarTableAdapter.Fill(this.parlakPansiyonDataSet2.Faturalar);

        }
    }
}
