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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
            
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=Gaming\SQLEXPRESS;Initial Catalog=ParlakDilKursu;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            PanelDesign();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select count(AdSoyad) as Toplam from OgrenciKayit", baglanti);

            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                label1.Text = oku["Toplam"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(Cinsiyet) as Toplam1 from OgrenciKayit where Cinsiyet='Bay'", baglanti);

            SqlDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                label8.Text = oku1["Toplam1"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(Cinsiyet) as Toplam2 from OgrenciKayit where Cinsiyet='Bayan'", baglanti);

            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                label5.Text = oku2["Toplam2"].ToString();
            }
            baglanti.Close();
           
        }
        private void PanelDesign()
        {
            panel2.Visible = false;
            panel_kursMenü.Visible = false;
            panel_puanMenü.Visible = false;
        }
        private void ShowMenu(Panel menu)
        {
            if (menu.Visible == false)
            {
                HideMenu();
                menu.Visible = true;
            }
            else
            {
                menu.Visible = false;
            }
        }
        private void HideMenu()
        {
            if (panel2.Visible == true) panel2.Visible = false;
            if (panel_kursMenü.Visible == true) panel_kursMenü.Visible = false;
            if (panel_puanMenü.Visible == true) panel_puanMenü.Visible = false;
        }

        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            ShowMenu(panel2);
        }

        private void BtnOgrenciKayit_Click(object sender, EventArgs e)
        {
            HideMenu();
            Kayit frm = new Kayit();
            frm.Show();
            this.Hide();
        }

        private void BtnOgrenciYonetim_Click(object sender, EventArgs e)
        {
            HideMenu();
            OgrenciYonetimi frm = new OgrenciYonetimi();
            frm.Show();
            this.Hide();
        }

        private void Btnİcerik_Click(object sender, EventArgs e)
        {
            HideMenu();
        }

        private void BtnOgrenciYazdır_Click(object sender, EventArgs e)
        {
            HideMenu();
            OgrenciYazdir frm = new OgrenciYazdir();
            frm.Show();
            this.Hide();

        }

        private void BtnKurs_Click(object sender, EventArgs e)
        {
            ShowMenu(panel_kursMenü);
        }

        private void BtnKursYeniKayit_Click(object sender, EventArgs e)
        {
            HideMenu();
            YeniKurs frm = new YeniKurs();
            frm.Show();
            this.Hide();
        }

        private void BtnKayitYönetim_Click(object sender, EventArgs e)
        {
            HideMenu();
            KursYönetimi frm = new KursYönetimi();
            frm.Show();
            this.Hide();
        }

        private void BtnKursYazdır_Click(object sender, EventArgs e)
        {
            HideMenu();
            KursYazdir frm = new KursYazdir();
            frm.Show();
            this.Hide();
            
        }

        private void BtnPuanlar_Click(object sender, EventArgs e)
        {
            ShowMenu(panel_puanMenü);
        }

        private void BtnYeniPuan_Click(object sender, EventArgs e)
        {
            HideMenu();
            YeniPuan frm = new YeniPuan();
            frm.Show();
            this.Hide();

        }

        private void BtnPuanYönetim_Click(object sender, EventArgs e)
        {
            HideMenu();
            PuanYönetimi frm = new PuanYönetimi();
            frm.Show();
            this.Hide();
        }

        private void BtnPuanlarYazdir_Click(object sender, EventArgs e)
        {
            HideMenu();
            PuanYazdir frm = new PuanYazdir();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
