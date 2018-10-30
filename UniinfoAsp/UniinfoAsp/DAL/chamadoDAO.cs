using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniinfoAsp.Models;

namespace UniinfoAsp.DAL
{
    public class chamadoDAO
    {
        UnipEntities db = new UnipEntities();

        public List<Con_Chamado> Consultar()
        {
            var novo = db.Con_Chamado.ToList();
            return novo;
        }
    }
}