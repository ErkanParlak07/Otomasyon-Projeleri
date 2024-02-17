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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakPansiyon;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAdminGiris frm = new FrmAdminGiris();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmYeniMusteri frm = new FrmYeniMusteri();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmOdalar frm = new FrmOdalar();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMusteriler frm = new FrmMusteriler();
            frm.Show();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmGelirGider frm = new FrmGelirGider();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmStoklar frm = new FrmStoklar();
            frm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmRadyoDinle frm = new FrmRadyoDinle();
            frm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmGazete frm = new FrmGazete();
            frm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FrmSifreGuncelle frm = new FrmSifreGuncelle();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmMusteriMesaj frm = new FrmMusteriMesaj();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PARLAK PANSİYON 2004'TEN BERİ HİZMETİNİZDE");
        }
    }
}
