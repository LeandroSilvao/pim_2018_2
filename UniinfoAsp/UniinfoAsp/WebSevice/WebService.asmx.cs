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
        UnipEntities unip = new UnipEntities();
        [WebMethod]
        public string HelloWorld()
        {
            return "Olá, Mundo";
        }

        [WebMethod]
        public List<Con_Chamado> ConsultarChamado()
        {
            chamadoDAO dao = new chamadoDAO();
            return dao.Consultar();
        }
    }
}
