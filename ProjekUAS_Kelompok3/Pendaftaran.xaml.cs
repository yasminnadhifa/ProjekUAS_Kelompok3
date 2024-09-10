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
    /// Interaction logic for Pendaftaran.xaml
    /// </summary>
    public partial class Pendaftaran : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLOCALDB; Initial Catalog = uasbad; Integrated Security = True; Pooling = False");
        uasbadEntities1 _db = new uasbadEntities1();
        string pendaftar = null;
       
        public static DataGrid dataGrid;

        public Pendaftaran(string username)
        {
            InitializeComponent();
            pendaftar = username;
            user.Text = pendaftar;
            txtUsername.Text = pendaftar;
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

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {



        }


        private void ContohDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string programkelas = (contohDataGrid.SelectedItem as alat_musik).program_kelas;
            string biaya = (contohDataGrid.SelectedItem as alat_musik).iuran;
            txtPK.Text = programkelas;
            txtBiaya.Text = biaya;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string jk;

            if(cbLK.IsChecked == true)
            {
                jk = "Laki-laki";
            }
            else
            {
                jk = "Perempuan";
            }
            string hr="";
            if (cbRJ.IsChecked == true)
            {
                hr = "Rabu dan Jumat";
            }else if(cbSK.IsChecked == true)
            {
                hr = "Selasa dan Kamis";
            }else if(cbSM.IsChecked == true)
            {
                hr = "Sabtu dan Minggu";
            }else if(cbSR.IsChecked == true)
            {
                hr = "Senin dan Rabu";
            }
            pendaftaran newPendaftar = new pendaftaran()
            {

                username = txtUsername.Text,
                nama = txtNama.Text,
                tanggal = txtTL.Text,
                nohp = txtHp.Text,
                pk = txtPK.Text,
                tipe = txtTipe.Text,
                jeniskelamin = jk,
                hari = hr


            };

            _db.pendaftarans.Add(newPendaftar);
            _db.SaveChanges();
            Pembayaran hm = new Pembayaran(pendaftar, txtPK.Text,txtBiaya.Text,txtNama.Text);
            hm.Show();
            this.Close();


        }

    }
    }

