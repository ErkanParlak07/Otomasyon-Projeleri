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
    public partial class PuanYönetimi : Form
    {
        public PuanYönetimi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakDilKursu;Integrated Security=True");

        private void PuanYönetimi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet13.Puan' table. You can move, or remove it, as needed.
            this.puanTableAdapter.Fill(this.parlakDilKursuDataSet13.Puan);

        }
        private void VerileriGoster()
        {
            this.puanTableAdapter.Fill(this.parlakDilKursuDataSet13.Puan);
        }
        int id;
        private void button1_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Puan where Puanid='" + id + "'", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show(" Silindi");
            VerileriGoster();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Puan set Ogrenciid='" + textBox1.Text + "',Puan='" + textBox2.Text + "',Kurs='" + comboBox1.Text + "',Aciklama='" + richTextBox1.Text + "'where Puanid='"+ id+"'" , baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Güncellendi");
            VerileriGoster();
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            richTextBox1.Text = "";
            comboBox1.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();           
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();           
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Puan where Ogrenciid like '%" + textBox3.Text + "%' ", baglanti);
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Hide();
        }
    }
}
