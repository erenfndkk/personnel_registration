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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-G0ALQ5C\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void Temizle()
        {
            txt_Id.Text = "";
            txt_Ad.Text = "";
            txt_Sayad.Text = "";
            txt_meslek.Text = "";
            cmb_sehir.Text = "";
            msk_maas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txt_Ad.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelVeriTabaniDataSet.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("insert into Tbl_Personel" +
                " (Per_ad,Per_Soyad,Per_Sehir,Per_Maas,Per_Meslek,Per_Medeni_Durum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txt_Ad.Text);
            komut.Parameters.AddWithValue("@p2", txt_Sayad.Text);
            komut.Parameters.AddWithValue("@p3", cmb_sehir.Text );
            komut.Parameters.AddWithValue("@p4", msk_maas.Text);
            komut.Parameters.AddWithValue("@p5", txt_meslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked== true)
            {
                label8.Text = "False";
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txt_Id.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_Ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_Sayad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmb_sehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msk_maas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();    
            txt_meslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text =="True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text =="False")
            {
                radioButton2.Checked = true;    
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutSil = new SqlCommand("Delete From Tbl_Personel Where Per_Id=@k1", baglanti);
            komutSil.Parameters.AddWithValue("@k1", txt_Id.Text);
            komutSil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Kayıt silindi");
        }

        private void btn_gunceller_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komutGuncelle = new SqlCommand("Update Tbl_Personel Set Per_Ad=@a1,Per_Soyad=@a2,Per_Sehir=@a3,per_Maas=@a4,Per_Medeni_Durum=@a5,Per_Meslek=@a6 where per_Id=@a7", baglanti);
            komutGuncelle.Parameters.AddWithValue("@a1", txt_Ad.Text);
            komutGuncelle.Parameters.AddWithValue("@a2", txt_Sayad.Text);
            komutGuncelle.Parameters.AddWithValue("@a3", cmb_sehir.Text);
            komutGuncelle.Parameters.AddWithValue("@a4", msk_maas.Text);
            komutGuncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutGuncelle.Parameters.AddWithValue("@a6", txt_meslek.Text);
            komutGuncelle.Parameters.AddWithValue("@a7", txt_Id.Text);
            komutGuncelle.ExecuteNonQuery();
            MessageBox.Show("Personel Bilgi Güncellendi");

            baglanti.Close();
        }

        private void btn_istatistik_Click(object sender, EventArgs e)
        {
           frmistatistik fr = new frmistatistik();
            fr.Show();
        }
    }
}
