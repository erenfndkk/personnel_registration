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
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-G0ALQ5C\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //şehir greafiği
            baglanti.Open();

            SqlCommand komutGrafik1 = new SqlCommand("select Per_Sehir, count(*) From Tbl_Personel group by Per_Sehir", baglanti);
            SqlDataReader dr1 = komutGrafik1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }

            baglanti.Close();

            //meslek-maaş grafiği
            baglanti.Open();

            SqlCommand komutGrafik2 = new SqlCommand("select Per_Meslek, avg(Per_Maas) From Tbl_Personel group by Per_Meslek", baglanti);
            SqlDataReader dr2 = komutGrafik2.ExecuteReader();
            while(dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }

            baglanti.Close();
        }
    }
}
