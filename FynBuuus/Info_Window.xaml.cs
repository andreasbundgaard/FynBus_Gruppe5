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
    public partial class Info_Window : Window 
    {
        public string PreSelectedItem;
        Controller _controller = new Controller();
        public Info_Window() 
        {
            InitializeComponent();
            string firmaInfo = "Firma information";
            string firmaPriser = "Priser";
            string firmaTilladelser = "Tilladelser";
            SelectInfo.Items.Add(firmaInfo);
            SelectInfo.Items.Add(firmaPriser);
            SelectInfo.Items.Add(firmaTilladelser);
        }

        private void Oversigt_Click(object sender, RoutedEventArgs e) 
        {
            new MainWindow().Show();
            this.Close(); 
        }

        private void Detaljer_Click(object sender, RoutedEventArgs e) 
        {
            new Detaljer_Window().Show();
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SelectInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _controller.FirmaPriserTilladelser(PreSelectedItem);
            HovedInfo.Items.Clear();
            for (int i = 0; i < _controller.Firmaliste.Count; i++)
            {
                if (_controller.Firmaliste[i].CVRnr.Equals(PreSelectedItem))
                {
                    if (SelectInfo.SelectedItem == "Firma information")
                    {
                        HovedInfo.Items.Add(_controller.Firmaliste[i].Navn);
                        HovedInfo.Items.Add(_controller.Firmaliste[i].YderligOplys);
                        HovedInfo.Items.Add(_controller.Firmaliste[i].CVRnr);
                        HovedInfo.Items.Add(_controller.Firmaliste[i].SekundFirma);
                    }
                    if (SelectInfo.SelectedItem == "Priser")
                    {
                        for (int j = 0; j < _controller.Firmaliste[i].Prisliste.Count; j++)
                        {
                            HovedInfo.Items.Add("Vogntype: " + _controller.Firmaliste[i].Prisliste[j].TypeVogn);
                            HovedInfo.Items.Add("Hverdags priser:");
                            HovedInfo.Items.Add("   Start gebyr: " + _controller.Firmaliste[i].Prisliste[j].SGebyrH);
                            HovedInfo.Items.Add("   Vente pris: " + _controller.Firmaliste[i].Prisliste[j].PrisVenteH);
                            HovedInfo.Items.Add("   Køre pris: " + _controller.Firmaliste[i].Prisliste[j].PrisKøreH);
                            HovedInfo.Items.Add("Aften og nat priser:");
                            HovedInfo.Items.Add("   Start gebyr: " + _controller.Firmaliste[i].Prisliste[j].SGebyrAN);
                            HovedInfo.Items.Add("   Vente pris: " + _controller.Firmaliste[i].Prisliste[j].PrisVenteAN);
                            HovedInfo.Items.Add("   Køre pris: " + _controller.Firmaliste[i].Prisliste[j].PrisKøreAN);
                            HovedInfo.Items.Add("Weekends pris:");
                            HovedInfo.Items.Add("   Start gebyr: " + _controller.Firmaliste[i].Prisliste[j].SGebyrWH);
                            HovedInfo.Items.Add("   Vente pris: " + _controller.Firmaliste[i].Prisliste[j].PrisVenteWH);
                            HovedInfo.Items.Add("   Køre pris: " + _controller.Firmaliste[i].Prisliste[j].PriserKøreWH);
                            HovedInfo.Items.Add("Pris pr. løft med Trappemaskine:");
                            HovedInfo.Items.Add(_controller.Firmaliste[i].Prisliste[j].PrisTrappeLøft);
                        }
                    }
                    if (SelectInfo.SelectedItem == "Tilladelser")
                    {
                        for (int j = 0; j < _controller.Firmaliste[i].Tilladelsesliste.Count; j++)
                        {
                            HovedInfo.Items.Add("Tilladelses nr: " + _controller.Firmaliste[i].Tilladelsesliste[j].TilladelsesNr);
                            HovedInfo.Items.Add("Type: " + _controller.Firmaliste[i].Tilladelsesliste[j].TilladelseType);
                            HovedInfo.Items.Add("Gyldig til: " + _controller.Firmaliste[i].Tilladelsesliste[j].GyldigTil);
                            HovedInfo.Items.Add("Registerings nr: " + _controller.Firmaliste[i].Tilladelsesliste[j].RegNummer);
                            HovedInfo.Items.Add("Klar til drift: " + _controller.Firmaliste[i].Tilladelsesliste[j].KlarTilDrift);
                            HovedInfo.Items.Add("Bemærkninger: " + _controller.Firmaliste[i].Tilladelsesliste[j].BemaerkningerTilDoku);
                            HovedInfo.Items.Add("Første registeret tur: " + _controller.Firmaliste[i].Tilladelsesliste[j].DatoForKoretojsForsteReg);
                            HovedInfo.Items.Add("Trafikselskab: " + _controller.Firmaliste[i].Tilladelsesliste[j].TrafikSelskab);
                            HovedInfo.Items.Add("Udstedende myndighed: " + _controller.Firmaliste[i].Tilladelsesliste[j].UdstedendeMyndighed);
                        }
                    }
                }
            }
        }
    }
}
