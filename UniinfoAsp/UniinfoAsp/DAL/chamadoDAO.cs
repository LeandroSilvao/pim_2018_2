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

        public IEnumerable<Chamado> Consultar()
        {
            return db.Chamadoes.Where(c => c.statusAtendimento.Equals("Aberto")).ToList();
        }
    }
}