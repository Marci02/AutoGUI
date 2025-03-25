using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Auto> autok = Auto.LoadFromCsv("carsData.csv");
        public MainWindow()
        {
            InitializeComponent();
            GyartoList.ItemsSource = autok.Select(x => x.Gyarto.GyartoNev).Distinct().ToList();
            GyartoList.SelectedIndex = 0;
        }

        private void GyartoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KarosszeriaCombo.Items.Clear();
            ValtoCombo.Items.Clear();

            var selected = GyartoList.SelectedItem.ToString();

            var filtered = autok.Where(x => x.Gyarto.GyartoNev == selected).ToList();

            foreach (var item in filtered)
            {
                if(!KarosszeriaCombo.Items.Contains(item.Karosszeria.KarosszeriaNev))
                KarosszeriaCombo.Items.Add(item.Karosszeria.KarosszeriaNev);

                if(!ValtoCombo.Items.Contains(item.Valto.ValtoNev))
                ValtoCombo.Items.Add(item.Valto.ValtoNev);
            }

            KarosszeriaCombo.SelectedIndex = 0;
            ValtoCombo.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KeresesList.Items.Clear();
            var selectedGyarto = GyartoList.SelectedItem.ToString();
            var selectedKarosszeria = KarosszeriaCombo.SelectedItem.ToString();
            var selectedValto = ValtoCombo.SelectedItem.ToString();
            var selectedAjto = RadioTwo.IsChecked == true ? 2 : RadioThree.IsChecked == true ? 3 : RadioFour.IsChecked == true ? 4 : RadioFive.IsChecked == true ? 5 : 0;
            var selectedFrom = int.Parse(FromText.Text);
            var selectedTo = int.Parse(ToText.Text);

            var filtered = autok.Where(x =>x.Gyarto.GyartoNev == selectedGyarto && x.Karosszeria.KarosszeriaNev == selectedKarosszeria && x.Valto.ValtoNev == selectedValto && x.Ajtok == selectedAjto && x.Evjarat >= DateTime.Now.Year - selectedFrom && x.Evjarat <= DateTime.Now.Year - selectedTo).ToList();

            foreach (var item in filtered)
            {
                KeresesList.Items.Add($"{item.Azonosito}. - {item.Evjarat} - {item.Modell} - {item.Km} km - {item.Ar} CAD");
            }

        }
    }
}