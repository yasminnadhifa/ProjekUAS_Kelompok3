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
    /// Interaction logic for Admin_alatmusik.xaml
    /// </summary>
    public partial class Admin_alatmusik : Window
    {
        uasbadEntities1 _db = new uasbadEntities1();
        public static DataGrid dataGrid;

        public Admin_alatmusik()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            contohDataGrid.ItemsSource = _db.alat_musik.ToList();
            dataGrid = contohDataGrid;
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
        private void BtnTambah_Click(object sender, RoutedEventArgs e)
        {
            Admin_TambahAM ipage = new Admin_TambahAM();
            ipage.ShowDialog();
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Id = (contohDataGrid.SelectedItem as alat_musik).Id;
            string programkelas = (contohDataGrid.SelectedItem as alat_musik).program_kelas;
            string iuran = (contohDataGrid.SelectedItem as alat_musik).iuran;
            string durasi = (contohDataGrid.SelectedItem as alat_musik).durasi;
            string keterangan = (contohDataGrid.SelectedItem as alat_musik).keterangan;
            Admin_EditAM upage = new Admin_EditAM(Id, programkelas, iuran, durasi, keterangan);
            upage.ShowDialog();
        }
        private void BtnHapus_Click(object sender, RoutedEventArgs e)
        {
            int Id = (contohDataGrid.SelectedItem as alat_musik).Id;
            var hapusAM = _db.alat_musik.Where(m => m.Id == Id).Single();
            _db.alat_musik.Remove(hapusAM);
            _db.SaveChanges();
            contohDataGrid.ItemsSource = _db.alat_musik.ToList();
        }
    }
}
