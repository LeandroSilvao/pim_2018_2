using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UniinfoAsp.DAL;
using UniinfoAsp.Models;

namespace UniinfoAsp.WebSevice
{
    /// <summary>
    /// Descrição resumida de WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        chamadoDAO dao = new chamadoDAO();
        [WebMethod]
        public string HelloWorld()
        {
            return "Olá, Mundo";
        }

        [WebMethod]
        public List<Con_Chamado> ConsultarChamado()
        {
            return dao.Consultar();
        }

        [WebMethod]
        public List<Chamado> Consultar2()
        {
            return dao.Consultar2();
        }

        [WebMethod]
        public string verificanivel(string loginwpf, string senhawpf)
        {
            return dao.verificaLogin(loginwpf, senhawpf);
        }
    }
}
