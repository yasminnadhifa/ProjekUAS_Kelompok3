using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Pembayaran.xaml
    /// </summary>
    public partial class Pembayaran : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLOCALDB; Initial Catalog = uasbad; Integrated Security = True; Pooling = False");
        uasbadEntities1 _db = new uasbadEntities1();

        string pendaftar = null;
        string pk;
        string biaya;
        string namalengkap;
        public Pembayaran(string username,string program_kelas,string iuran, string nama)
        {
            InitializeComponent();
            pendaftar = username;
            user.Text = pendaftar;

            pk = program_kelas;
            txtPK.Text = pk;

            biaya = iuran;
            txtBiaya.Text = biaya;

            namalengkap = nama;
            txtNama.Text = namalengkap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float totalbiaya = Convert.ToInt32(txtBiaya.Text) * Convert.ToInt32(txtBulan.Text);


            pembayaran newPembayar = new pembayaran()
            {
                username = user.Text,
                nama = txtNama.Text,
                pk = txtPK.Text,
                total = totalbiaya,
                bulan = txtBulan.Text,
                iuran = txtBiaya.Text,
                status = "Belum melakukan pembayaran"
                


            };

            _db.pembayarans.Add(newPembayar);
            _db.SaveChanges();
            MessageBox.Show("Terima kasih telah mendaftar, silahkan menuju meja administrasi untuk membayar" +
                "\nTotal yang harus dibayarkan adalah " + totalbiaya);
            clearform();
            Profil hm = new Profil(pendaftar);
            hm.Show();
            this.Close();

        }
        private void clearform()
        {
            txtBulan.Clear();
            txtBiaya.Clear();
            txtPK.Clear();
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
        private void About_Click(object sender, RoutedEventArgs e)
        {
            About hm = new About(pendaftar);
            hm.Show();
            this.Close();
        }

        private void Pendaftaran_Click(object sender, RoutedEventArgs e)
        {
            Pendaftaran hm = new Pendaftaran(pendaftar);
            hm.Show();
            this.Close();
        }

        private void Testimonial_Click(object sender, RoutedEventArgs e)
        {
            Testimonial hm = new Testimonial(pendaftar);
            hm.Show();
            this.Close();
        }

        private void Profil_Click(object sender, RoutedEventArgs e)
        {
            Profil hm = new Profil(pendaftar);
            hm.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
            MessageBox.Show("Terima kasih telah mengunjungi kami!");
        }
    }
}
