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
    /// Interaction logic for Admin_Pembayaran.xaml
    /// </summary>
    public partial class Admin_Pembayaran : Window
    {
        uasbadEntities1 _db = new uasbadEntities1();
        public static DataGrid dataGrid;
        public Admin_Pembayaran()
        {
            InitializeComponent(); Load();
        }
        private void Load()
        {
            contohDataGrid.ItemsSource = _db.pembayarans.ToList();
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
        private void BtnHapus_Click(object sender, RoutedEventArgs e)
        {
            int Id = (contohDataGrid.SelectedItem as pembayaran).Id;
            var hapusPembayaran = _db.pembayarans.Where(m => m.Id == Id).Single();
            _db.pembayarans.Remove(hapusPembayaran);
            _db.SaveChanges();
            contohDataGrid.ItemsSource = _db.pembayarans.ToList();
        }
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {

            int Id = (contohDataGrid.SelectedItem as pembayaran).Id;
            string nama = (contohDataGrid.SelectedItem as pembayaran).nama;
            string pk = (contohDataGrid.SelectedItem as pembayaran).pk;
            string bulan = (contohDataGrid.SelectedItem as pembayaran).bulan;
            double total = (double)(contohDataGrid.SelectedItem as pembayaran).total;
            string status = (contohDataGrid.SelectedItem as pembayaran).status;
            string halo = Convert.ToString(total);
            Admin_EditStatus upage = new Admin_EditStatus(Id, nama, pk, bulan, halo, status);
            upage.ShowDialog();
        }
    }
}
