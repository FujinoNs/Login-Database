using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace Login_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection connect = new MySqlConnection("host=localhost;user=root;database=launcher");
        MySqlDataAdapter adapter;
        DataTable table;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void openConnect()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
            }
            catch { }
        }
        public void closeConnect()
        {
            try
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
            catch { }
        }

        public void datalogin(string query)
        {
            try
            {
                openConnect();
                adapter = new MySqlDataAdapter(query, connect);
                table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    this.Hide();
                    wd_mainapp _Main = new wd_mainapp();
                    _Main.Show();
                }
                else
                {
                    MessageBox.Show("ไม่พบข้อมูลผู้ใช้!", "แจ้งเตือน!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                closeConnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btn_login_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = "SELECT * FROM launcher.login WHERE username ='" + txt_user.Text + "' AND password='" + txt_pass.Password + "'";
                datalogin(login);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "แจ้งเตือน!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
