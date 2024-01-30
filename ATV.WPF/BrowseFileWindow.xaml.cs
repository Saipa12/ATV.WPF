using MaterialDesignColors.Recommended;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Spire.Xls;

namespace ATV.WPF
{
    /// <summary>
    /// Логика взаимодействия для BrowseFileWindow.xaml
    /// </summary>
    public partial class BrowseFileWindow : Window
    {
        private PackIcon packIconMaximize = new PackIcon();
        private PackIcon packIconRestore = new PackIcon();
        public string FilePath;
        public BrowseFileWindow()
        {
            InitializeComponent();
            packIconMaximize.Kind = PackIconKind.WindowMaximize;
            packIconRestore.Kind = PackIconKind.WindowRestore;
        }
        private void GridControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void CloseApplicationButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeWindowButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;


        private void MaximizeWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                MaximizeApplicationButton.Content = packIconMaximize;
            }
            else
            {
                WindowState = WindowState.Maximized;
                MaximizeApplicationButton.Content = packIconRestore;
            }
                        
        }

        private void BrowseApplicationButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files | *.xls;*.xlsm;*.xlsx;*.csv;*.xlsb";
            openFileDialog.Title = "Import Usarius";
            openFileDialog.ShowDialog();
            FilePath = openFileDialog.FileName;
        }

        private void CloseApplicationButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#c42b1c"));
        }

        private void CloseApplicationButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Background = Brushes.Transparent;
        }

        private void BrowseApplicationTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).BorderBrush = Brushes.Blue;
              
        }
    }
}