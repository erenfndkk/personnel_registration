using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_kayit
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-G0ALQ5C\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void frmistatistik_Load(object sender, EventArgs e)
        {
            // toplam personel sayısı
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select count (*) From Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbl_ToplamPer.Text= dr1[0].ToString();
            }

            baglanti.Close();

            //Evli personel sayısı
            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("select count (*) From Tbl_Personel where Per_Medeni_Durum = 1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
                lbl_EvliPer.Text= dr2[0].ToString();
            }

            baglanti.Close();

            //bekar personel sayısı
            baglanti.Open();

            SqlCommand komut3 = new SqlCommand("select count(*) From Tbl_Personel where Per_Medeni_Durum = 0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while(dr3.Read())
            {
                lbl_BekarPer.Text = dr3[0].ToString();
            }


            baglanti.Close();

            //şehir sayısı
            baglanti.Open();

            SqlCommand komut4 = new SqlCommand("select count (distinct (Per_Sehir)) From Tbl_Personel", baglanti);
            SqlDataReader d4 = komut4.ExecuteReader();
            while(d4.Read())
            {
                lbl_SehirSayısı.Text = d4[0].ToString();
            }

            baglanti.Close();

            //Toplam maaş
            baglanti.Open();

            SqlCommand komut5 = new SqlCommand("select sum(Per_Maas) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbl_ToplamMaas.Text = dr5[0].ToString();
            }

            baglanti.Close();

            //ortalama maaş
            baglanti.Open();

            SqlCommand komut6 = new SqlCommand("select avg(Per_Maas) From Tbl_Personel", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lbl_OrtalamaMaas.Text = dr6[0].ToString();
            }

            baglanti.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
