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
    public partial class FrmMusteriMesaj : Form
    {
        public FrmMusteriMesaj()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakPansiyon;Integrated Security=True");

        private void FrmMusteriMesaj_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parlakPansiyonDataSet3.MusteriMesaj' table. You can move, or remove it, as needed.
            this.musteriMesajTableAdapter.Fill(this.parlakPansiyonDataSet3.MusteriMesaj);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into MusteriMesaj (AdSoyad,Mesaj) values('" + textBox1.Text + "','" + richTextBox1.Text + "' )", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            this.musteriMesajTableAdapter.Fill(this.parlakPansiyonDataSet3.MusteriMesaj);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update MusteriMesaj set AdSoyad='"+ textBox1.Text+ "',Mesaj='"+ richTextBox1.Text+"'  ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            this.musteriMesajTableAdapter.Fill(this.parlakPansiyonDataSet3.MusteriMesaj);
        }
    }
}
