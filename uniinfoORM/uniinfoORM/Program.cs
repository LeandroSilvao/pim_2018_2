using System;
using System.Linq;
using uniinfo.Extensions;
using uniinfoORM.Controller;
using uniinfoORM.Model;

namespace uniinfoORM
{
    class Program
    {
        static void Main(string[] args)
        {
            UniinfoContext context = new UniinfoContext();
            context.LogSQLToConsole();

            var PegandoAdmInicial = context.Funcionarios.Where(f => (f.nivelAcesso.Equals(1)) && (f.nome.Contains("k"))).ToList();
            var pegandoLoginId = context.Funcionarios.Where(f => (f.loginId.Id.Equals(1))).ToList();

            foreach ( var adm in PegandoAdmInicial)
            {
                Console.WriteLine(adm);
            }

        }
    }
}
