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

namespace FynBuuus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {  
        List<string> tjekListe;
        Controller _controller = new Controller();
        public MainWindow()
        {
            InitializeComponent();
            _controller.FirmaPriserTilladelser("");
            tjekListe = new List<string>();
            foreach (Firma f in _controller.Firmaliste)
            {
                string navnCVRnr ="Firma: " + f.Navn + ", CVRnr: " + f.CVRnr;
                CVR_List.Items.Add(navnCVRnr);
                tjekListe.Add(navnCVRnr);
            }
        }

        private void Information_Click(object sender, RoutedEventArgs e) {
            new Info_Window().Show();
            this.Close(); 
        }

        private void CVR_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FirmaInfo.Items.Clear();
            for (int i = 0; i < tjekListe.Count; i++)
            {
                if (tjekListe[i].Equals(CVR_List.SelectedItem))
                {
                    string firmainformation = "OpLysninger: " + "\n" + _controller.Firmaliste[i].YderligOplys + "\nSenkundært firma:\n" + _controller.Firmaliste[i].SekundFirma;
                    FirmaInfo.Items.Add(firmainformation);
                }
            }
        }
    }
}
