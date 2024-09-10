using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLOCALDB; Initial Catalog = uasbad; Integrated Security = True; Pooling = False");

        public Login()
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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(passwordBox.Password) && passwordBox.Password.Length > 0)
                textPassword.Visibility = Visibility.Collapsed;
            else
                textPassword.Visibility = Visibility.Visible;
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            passwordBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            con.Open();
            string username = null;

            if (txtUsername.Text== "" || passwordBox.Password == "")
            {
                MessageBox.Show("Mohon masukan nama atau kata sandi anda terlebih dahulu");

            }
            else
            {
                SqlDataAdapter dtap = new SqlDataAdapter("select username,password,role from [user] where username='"+txtUsername.Text+"' AND password = '"+passwordBox.Password+ "'", con);
                DataTable dt = new DataTable();
                dtap.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        if(dr["role"].ToString() == "Admin")
                        {

                            Admin_Testimonial hi = new Admin_Testimonial();
                            hi.Show();
                            this.Close();

                        }
                        else if (dr["role"].ToString() == "User")
                        {
                            username = txtUsername.Text;

                            About hi = new About(username);
                            hi.Show();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Maaf username atau password anda salah, mohon kontak admin!");
                }
                con.Close();
            }

        }

    



        private void txtUsername_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) && txtUsername.Text.Length > 0)
                textUsername.Visibility = Visibility.Collapsed;
            else
                textUsername.Visibility = Visibility.Visible;
        }

        private void textUsername_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtUsername.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Register hm = new Register();
            hm.Show();
            this.Close();

        }
    }
}
    