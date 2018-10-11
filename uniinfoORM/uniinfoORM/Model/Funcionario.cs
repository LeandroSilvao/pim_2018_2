using System.Collections.Generic;

namespace uniinfoORM.Model
{
    public class Funcionario
    {
        public int Id { get; set; }
        public Loginn loginId { get; set; }
        public string nome { get; set; }
        public int ramal { get; set; }
        public int nComputador { get; set; }
        public string email { get; set; }
        public string setor { get; set; }
        public int nivelAcesso { get; set; }
        public IList<Chamado> FuncionarioId { get; set; }
        public IList<ChamadoAtendimento> ChamadosPorFuncionario { get; set; }

        public Funcionario()
        {
            FuncionarioId = new List<Chamado>();
            ChamadosPorFuncionario = new List<ChamadoAtendimento>();
        }

        public override string ToString()
        {
            return $"{Id} {nome} {loginId} {ramal} {nComputador} {email} {setor} {nivelAcesso}";
        }
    }
}
