using System.Collections.Generic;

namespace uniinfoORM.Model
{
    public class Chamado
    {
        public int Id { get; set; }
        public Funcionario IdFuncionario { get; set; }
        public tipoProblema IdProblema { get; set; }
        public string descricao { get; set; }
        public string statusAtendimento { get; set; }
        public IList<ChamadoAtendimento> chamados { get; set; }

        public Chamado()
        {
            chamados = new  List<ChamadoAtendimento>();
        }

        public override string ToString()
        {
            return $"{Id} {descricao} {statusAtendimento}";
        }
    }
}
