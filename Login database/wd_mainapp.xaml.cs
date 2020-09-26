using System.Windows;
using System.Windows.Input;

namespace Login_database
{
    /// <summary>
    /// Interaction logic for wd_mainapp.xaml
    /// </summary>
    public partial class wd_mainapp : Window
    {
        public wd_mainapp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
