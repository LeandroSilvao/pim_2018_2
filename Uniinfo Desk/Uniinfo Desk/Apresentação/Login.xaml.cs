using System;
using System.Threading;
using System.Windows;
using Uniinfo_Desk.Apresentação;
using Uniinfo_Desk.ServiceReference;

namespace Uniinfo_Desk
{
    
    public partial class MainWindow : Window
    {
       Inicio Inicio = new Inicio();

        SplashScreen splash = new SplashScreen("Apresentação/home.png");
        //splash.Show(false);
        //Thread.Sleep(3000);
        //splash.Close(new TimeSpan(0, 0, 1));

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
                if (txbUsuário.Text == "" && psdSenha.Password == "") { txbErros.Text = "Digite seu Usuário e sua Senha"; }
                else if (txbUsuário.Text == "") { txbErros.Text = "Digite seu Usuário"; }
                else if (psdSenha.Password == "") { txbErros.Text = "Digite sua Senha"; }
               
                else if (Status == "true")
                {

                    mnaLogin.Close();

                    SplashScreen splash = new SplashScreen("Apresentação/Imagens/Inicial.png");
                    splash.Show(false);
                    Thread.Sleep(3000);
                    splash.Close(new TimeSpan(0, 0, 1));

                    Inicio.mnConsulta.Show();
                    Inicio.Grid_Loaded(sender, e);
                }
                else { txbErros.Text = "Usuário ou Senha incorreto"; }

            }
            catch (System.Exception)
            {
               txbErros.Text= "Falha na conexão com o servidor de Login";
            }
        }

        private void txbSenha_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
