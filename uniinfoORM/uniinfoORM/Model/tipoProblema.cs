using System;
using System.Collections.Generic;
using System.Text;

namespace uniinfoORM.Model
{
    public class tipoProblema
    {
        public int Id { get; set; }
        public string tipoDoProblema { get; set; }
        public IList<Chamado> problemaId { get; set; }

        public tipoProblema()
        {
            problemaId = new List<Chamado>();
        }

        public override string ToString()
        {
            return $"{Id} {tipoDoProblema}";
        }
    }
}
