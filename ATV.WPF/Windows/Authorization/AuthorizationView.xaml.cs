using System.Windows;
using System.Windows.Input;

namespace ATV.WPF.Windows.Authorization
{
    public partial class AuthorizationView : Window
    {
        public AuthorizationView() => InitializeComponent();

        private void GridControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void CloseApplicationButton_Click(object sender, RoutedEventArgs e) => Close();

        private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
    }
}
