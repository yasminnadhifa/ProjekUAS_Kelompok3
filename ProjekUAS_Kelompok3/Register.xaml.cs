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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        uasbadEntities1 _db = new uasbadEntities1();
        public Register()
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
            user newUser = new user()
            {
                nama = txtNama.Text,
                username = txtUsername.Text,
                password = passwordBox.Password,
                role = "User"

            };
            
            _db.users.Add(newUser);
            _db.SaveChanges();

            Login hm = new Login();
            hm.Show();
            this.Close();
            MessageBox.Show("Selamat Anda Berhasil Melakukan Registrasi, silahkan login!");
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

        private void txtNama_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNama.Text) && txtNama.Text.Length > 0)
                textNama.Visibility = Visibility.Collapsed;
            else
                textNama.Visibility = Visibility.Visible;
        }

        private void textNama_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtNama.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Login hm = new Login();
            hm.Show();
            this.Close();
        }

    }
}