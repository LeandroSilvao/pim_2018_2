
using System.Windows;
using Uniinfo_Desk.ServiceReference;


namespace Uniinfo_Desk.Apresentação
{
  
    public partial class Inicio : Window
    {
        
        
        
        public Inicio()
        {
            InitializeComponent();
            

        }

       

        public void btnLogar_Click_1(object sender, RoutedEventArgs e)
        {
            Grid_Loaded(sender, e);
        }


        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Login = new MainWindow();
            mnConsulta.Close();
            Login.mnaLogin.ShowDialog();

        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        public void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                WebServiceSoapClient obj = new WebServiceSoapClient();
                grid.ItemsSource = obj.ConsultarChamado();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Falha na Conexão com o Web Service");
            }
            

        }


    }
}
