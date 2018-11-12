
using System.Windows;
using System.Windows.Controls;
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

        private void grid_AutoGeneratingColumn(object sender, System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs e)
        {

            
            

            if (e.PropertyName == "ExtensionData")
            {
                e.Column = null;
            }
            if (e.PropertyName == "dataChamado")
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
                e.Column.Header = "Data de Abertura";
                
            }

           
            if (e.PropertyName.StartsWith("descricao"))
            {
                e.Column.Header = "Descrição";
            }
            if (e.PropertyName.StartsWith("statusAtendimento"))
            {
                e.Column.Header = "Status do Atendimento";
            }
            if (e.PropertyName.StartsWith("nome"))
            {
                e.Column.Header = "Nome";
            }
        }

        private void btnLoggout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Login = new MainWindow();
            mnConsulta.Close();
            Login.mnaLogin.ShowDialog();
        }
    }
}
