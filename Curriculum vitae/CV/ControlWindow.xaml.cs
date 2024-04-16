using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace CV
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        MainWindow mainWindow = new MainWindow();
        public ControlWindow()
        {
            InitializeComponent();
            this.Loaded += LoadMainWindow;
            PinWindow();
        }
 
        private void LoadMainWindow(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.Show();
                mainWindow.Topmost = true;
            }
            catch (Exception exLoadMainWindow)
            {
                MessageBox.Show(exLoadMainWindow.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainWindow.Visibility = Visibility.Collapsed;
               
            }
            catch (Exception exCloseMainWindow)
            {
                MessageBox.Show("inside"+ exCloseMainWindow.Message);
            }
        }

        private void btnFixSize_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Top = 0;
            mainWindow.Left = 100;
        }

        private void btnReopen_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Visibility = Visibility.Visible;
        }

        private void btnPin_Click(object sender, RoutedEventArgs e)
        {
            if (this.Topmost == true) { this.Topmost = false; btnPin.Foreground = Brushes.LightGoldenrodYellow; }
            else { this.Topmost = true; btnPin.Foreground = Brushes.Red; }
        }
        private void PinWindow()
        {
            btnPin.Foreground = Brushes.Red;
            this.Topmost = true;
        }

        private void btnCloseControls_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
            this.Close();
            Environment.Exit(0);
        }

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
            if (e.GetPosition(this).Y <= 0)
            {
                this.WindowState = WindowState.Normal;
            }
        }
    }
}
