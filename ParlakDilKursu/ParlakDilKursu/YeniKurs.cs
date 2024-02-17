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
    public partial class YeniKurs : Form
    {
        public YeniKurs()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakDilKursu;Integrated Security=True");

        private void YeniKurs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet9.Kurs' table. You can move, or remove it, as needed.
            this.kursTableAdapter3.Fill(this.parlakDilKursuDataSet9.Kurs);
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet8.Kurs' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet7.Kurs' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'parlakDilKursuDataSet6.Kurs' table. You can move, or remove it, as needed.
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (TxtKursAdi.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
                
            else
            {
                
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Kurs values('" + TxtKursAdi.Text + "','" + richTextBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kurs Eklendi");
                this.kursTableAdapter3.Fill(this.parlakDilKursuDataSet9.Kurs);

                baglanti.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TxtKursAdi.Text = "";
            richTextBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
            this.Hide();
        }
    }
}
