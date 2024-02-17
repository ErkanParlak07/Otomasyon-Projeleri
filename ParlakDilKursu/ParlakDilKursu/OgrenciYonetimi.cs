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
    public partial class OgrenciYonetimi : Form
    {
        public OgrenciYonetimi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakDilKursu;Integrated Security=True");

        private void OgrenciYonetimi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet4.OgrenciKayit' table. You can move, or remove it, as needed.
            this.ogrenciKayitTableAdapter.Fill(this.parlakDilKursuDataSet4.OgrenciKayit);

        }
        private void verileriGoster()
        {
            this.ogrenciKayitTableAdapter.Fill(this.parlakDilKursuDataSet4.OgrenciKayit);
        }
        int id;
        private void button3_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
       
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from OgrenciKayit where Ogrenciid='" + id+"'", baglanti);
            komut.ExecuteNonQuery();
            verileriGoster();
            MessageBox.Show("Kayıt Silindi");
            baglanti.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update OgrenciKayit set AdSoyad='" + textBox1.Text+ "',Cinsiyet='" + comboBox1.Text + "',Resim='" + textBox4.Text + "',Adres='" + richTextBox1.Text + "',Telefon='" + textBox3.Text + "' where Ogrenciid='"+ id+ "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıt Güncellendi");
            verileriGoster();
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[3].Value.ToString();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            richTextBox1.Text ="" ;
            textBox3.Text = "";
            pictureBox1.ImageLocation = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox4.Text = openFileDialog1.FileName;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from OgrenciKayit where AdSoyad like '%" +textBox2.Text +"%' ", baglanti);
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
