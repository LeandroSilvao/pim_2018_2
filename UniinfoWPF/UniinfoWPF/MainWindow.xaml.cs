using System.Windows;
using UniinfoWPF.ServiceReference;

namespace UniinfoWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            WebServiceSoapClient obj = new WebServiceSoapClient();
            obj.HelloWorld();
            string teste = obj.HelloWorld();
            MessageBox.Show(teste);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            WebServiceSoapClient obj = new WebServiceSoapClient();
            grid.ItemsSource = obj.ConsultarChamado();
            
        }
    }
}
