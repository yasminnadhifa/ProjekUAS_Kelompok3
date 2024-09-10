using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekUAS_Kelompok3
{
    /// <summary>
    /// Interaction logic for Admin_Testimonial.xaml
    /// </summary>
    public partial class Admin_Testimonial : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLOCALDB; Initial Catalog = uasbad; Integrated Security = True; Pooling = False");
        uasbadEntities1 _db = new uasbadEntities1();
        public static DataGrid dataGrid;
        public Admin_Testimonial()
        {
            InitializeComponent();
            Load();
            jumlah();
            jumlah2();
            jumlah3();
        }
        private void Load()
        {
            contohDataGrid.ItemsSource = _db.testis.ToList();
            dataGrid = contohDataGrid;
        }
        private void jumlah()
        {
            con.Open();
            string query = "SELECT COUNT(*) as jumlah FROM [user]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                unitSewa.Text = dr["jumlah"].ToString() + " user";
            }
            con.Close();


        }

        private void jumlah2()
        {
            con.Open();
            string query = "SELECT COUNT(*) as jumlah FROM [pembayaran] where status = 'Lunas'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                unit.Text = dr["jumlah"].ToString() + " siswa";
            }
            con.Close();
        }
        private void jumlah3()
        {
            con.Open();
            string query = "SELECT COUNT(*) as jumlah FROM [alat_musik]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                alatmusik.Text = dr["jumlah"].ToString() + " program kelas";
            }
            con.Close();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Pendaftaran_Click(object sender, RoutedEventArgs e)
        {
            Admin_Pendaftaran hm = new Admin_Pendaftaran();
            hm.Show();
            this.Close();
        }
        private void Pembayaran_Click(object sender, RoutedEventArgs e)
        {
            Admin_Pembayaran hm = new Admin_Pembayaran();
            hm.Show();
            this.Close();
        }
        private void User_Click(object sender, RoutedEventArgs e)
        {
            Admin_Testimonial hm = new Admin_Testimonial();
            hm.Show();
            this.Close();
        }

        private void PK_Click(object sender, RoutedEventArgs e)
        {
            Admin_alatmusik hm = new Admin_alatmusik();
            hm.Show();
            this.Close();
        }
        private void BtnHapus_Click(object sender, RoutedEventArgs e)
        {
            int Id = (contohDataGrid.SelectedItem as testi).Id;
            var hapusTesti = _db.testis.Where(m => m.Id == Id).Single();
            _db.testis.Remove(hapusTesti);
            _db.SaveChanges();
            contohDataGrid.ItemsSource = _db.testis.ToList();
        }
    }
}
