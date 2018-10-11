using System;
using System.Collections.Generic;
using System.Text;

namespace uniinfoORM.Model
{
    public class ChamadoAtendimento
    {
        public int id { get; set; }
        public Funcionario IdFuncionario { get; set; }
        public Chamado IdChamado{ get; set; }

        public override string ToString()
        {
            return $"{id}";
        }
    }
}
