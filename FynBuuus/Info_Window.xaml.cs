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

namespace FynBuuus {
    /// <summary>
    /// Interaction logic for Info_Window.xaml
    /// </summary>
    public partial class Info_Window : Window {
        public Info_Window() {
            InitializeComponent();
        }

        private void Oversigt_Click(object sender, RoutedEventArgs e) {
            new MainWindow().Show();
            this.Close(); 
        }

        private void Detaljer_Click(object sender, RoutedEventArgs e) {
            new Detaljer_Window().Show();
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
