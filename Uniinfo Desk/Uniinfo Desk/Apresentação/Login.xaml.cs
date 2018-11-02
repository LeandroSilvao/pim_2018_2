using System;
using System.Windows;
using Uniinfo_Desk.Apresentação;
using Uniinfo_Desk.ServiceReference2;

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
            try
            {
                WebServiceSoapClient obj = new WebServiceSoapClient();

                string Status = obj.verificanivel(this.txbUsuário.Text, this.psdSenha.Password.ToString());
                if (Status == "true")
                {
                    Inicio.mnConsulta.Show();
                    mnaLogin.Close();
                    Inicio.Grid_Loaded(sender, e);
                }
                else { MessageBox.Show("Usuário ou Senha incorreto"); }

            }
            catch (System.Exception)
            {
                MessageBox.Show("Falha na conexão com o servidor de Login");
            }
        }

        private void txbSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
