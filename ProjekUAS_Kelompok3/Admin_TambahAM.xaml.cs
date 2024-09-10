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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjekUAS_Kelompok3
{
    /// <summary>
    /// Interaction logic for Admin_TambahAM.xaml
    /// </summary>
    public partial class Admin_TambahAM : Window
    {
        uasbadEntities1 _db = new uasbadEntities1();
        public Admin_TambahAM()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            alat_musik newAM = new alat_musik()
            {
                program_kelas = txtPK.Text,
                iuran = txtIuran.Text,
                durasi = txtDurasi.Text,
                keterangan = txtKeterangan.Text

            };

            _db.alat_musik.Add(newAM);
            _db.SaveChanges();
            Admin_alatmusik.dataGrid.ItemsSource = _db.alat_musik.ToList();
            this.Hide();
        }

        private void Tutup_Click(object sender, RoutedEventArgs e)
        {
            Admin_alatmusik hm = new Admin_alatmusik();
            hm.Show();
            this.Close();
        }
    }
}
