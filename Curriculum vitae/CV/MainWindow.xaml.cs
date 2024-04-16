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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
            if (e.GetPosition(this).Y <= 0)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                PrintDialog dlg = new PrintDialog();

                Window currentMainWindow = Application.Current.MainWindow;

                Application.Current.MainWindow = this;

                if ((bool)dlg.ShowDialog().GetValueOrDefault())
                {
                    Application.Current.MainWindow = currentMainWindow;
                    dlg.PrintVisual(this, "CV");
                }
            }
            catch (Exception exMouseDown)
            {
                MessageBox.Show(exMouseDown.Message);
            }
        }
    }
}
