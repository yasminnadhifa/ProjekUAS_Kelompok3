using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Testimonial.xaml
    /// </summary>
    public partial class Testimonial : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLOCALDB; Initial Catalog = uasbad; Integrated Security = True; Pooling = False");
        uasbadEntities1 _db = new uasbadEntities1();
        string pendaftar = null;
        public Testimonial(string username)
        {
            InitializeComponent();
            pendaftar = username;
            user.Text = pendaftar;
            txtUsername.Text = pendaftar;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Pendaftaran hm = new Pendaftaran(pendaftar);
            hm.Show();
            this.Close();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            About hm = new About(pendaftar);
            hm.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Testimonial hm = new Testimonial(pendaftar);
            hm.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Profil hm = new Profil(pendaftar);
            hm.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            testi newTesti = new testi()
            {

                username = txtUsername.Text,
                ulasan = txtTesti.Text,
                sk = txtSK.Text


            };

            _db.testis.Add(newTesti);
            _db.SaveChanges();
            MessageBox.Show("Terima kasih telah mengisi testimonial yang telah kami sediakan!");
            clearform();
        }
        private void clearform()
        {
            txtTesti.Clear();
            txtSK.Clear();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
            MessageBox.Show("Terima kasih telah mengunjungi kami!");

        }
    }
}
