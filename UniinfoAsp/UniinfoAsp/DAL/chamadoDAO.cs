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

        public List<Chamado> Consultar2()
        {
            var novo2 = db.Chamadoes.ToList();
            return novo2;
        }

        public string verificaLogin(string loginwpf, string senhawpf)
        {
            Loginn log = new Loginn();
            log.login = loginwpf;
            log.senha = senhawpf;

            var result = db.Loginns.Where(l => l.login == log.login && l.senha == log.senha).ToList();
            if (result.Count() > 0)
            {
                if (result[0].idNivelAcesso == 1)
                {
                    return "true";
                }
                return "false";
            }
            return "false";
        }
    }
}