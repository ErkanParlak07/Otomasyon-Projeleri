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
    public partial class KursYönetimi : Form
    {
        public KursYönetimi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakDilKursu;Integrated Security=True");

        private void KursYönetimi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet10.Kurs' table. You can move, or remove it, as needed.
            this.kursTableAdapter.Fill(this.parlakDilKursuDataSet10.Kurs);

        }
       private void VerileriGoster()
        {
            this.kursTableAdapter.Fill(this.parlakDilKursuDataSet10.Kurs);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }
        int id;
        private void button1_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Kurs where Kursid='" +id +"'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kurs Silindi");
            VerileriGoster();
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Kurs set KursAdi='" + textBox1.Text + "',Aciklama='" + richTextBox1.Text + "'where Kursid='"+ id+"'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kurs Güncellendi");
            VerileriGoster();
            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
