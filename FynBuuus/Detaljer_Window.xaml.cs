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
    /// Interaction logic for Detaljer_Window.xaml
    /// </summary>
    public partial class Detaljer_Window : Window {
        public Detaljer_Window() {
            InitializeComponent();
        }

        private void Ændre_Info_Click(object sender, RoutedEventArgs e) {

        }

        private void Til_Info_Window_Click(object sender, RoutedEventArgs e) {
            new Info_Window().Show();
            this.Close();
        }
    }
}
