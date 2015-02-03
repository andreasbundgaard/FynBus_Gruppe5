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
        Controller _controller = new Controller();
        public MainWindow()
        {
            InitializeComponent();
            _controller.FirmaPriserTilladelser("");
            foreach (Firma f in _controller.Firmaliste)
            {
                string navnCVRnr = f.Navn;
                CVR_List.Items.Add(navnCVRnr);
            }
        }

        private void Information_Click(object sender, RoutedEventArgs e) {
            Info_Window IW = new Info_Window();
            try
            {
                foreach (Firma f in _controller.Firmaliste)
                {
                    if (f.Navn.Equals(CVR_List.SelectedItem))
                    {
                        IW.PreSelectedItem = f.CVRnr;
                    }
                }
                IW.Show();
                this.Close(); 
            }
            catch
            {
                MessageBox.Show("Intet valgt");
            }
            
        }

        private void CVR_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FirmaInfo.Items.Clear();
            for (int i = 0; i < _controller.Firmaliste.Count; i++)
            {
                if (_controller.Firmaliste[i].Navn.Equals(CVR_List.SelectedItem))
                {
                    string firmainformation = "Oplysninger: " + "\nCVRnr: " + _controller.Firmaliste[i].CVRnr + "\n" + _controller.Firmaliste[i].YderligOplys;
                    if (_controller.Firmaliste[i].SekundFirma != "")
                    {
                        firmainformation = firmainformation + "\nSekundært firma:\n" + _controller.Firmaliste[i].SekundFirma;
                    }
                    firmainformation = firmainformation + "\nantal tilladelser: " + _controller.Firmaliste[i].Tilladelsesliste.Count;
                    FirmaInfo.Items.Add(firmainformation);
                }
            }
        }
    }
}
