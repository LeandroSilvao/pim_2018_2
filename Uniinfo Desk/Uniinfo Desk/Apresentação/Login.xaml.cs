using System.Windows;
using Uniinfo_Desk.Apresentação;

namespace Uniinfo_Desk
{
    
    public partial class MainWindow : Window
    {
       Inicio Inicio = new Inicio();

        public MainWindow()
        {
            InitializeComponent();
        }

     
        private void btnLogar_Click_1(object sender, RoutedEventArgs e)
        {
            Inicio.mnConsulta.Show();
            mnaLogin.Close();
            Inicio.Grid_Loaded(sender, e);
            
        }
    }
}
