using System.Collections.Generic;

namespace uniinfoORM.Model
{
    public class Loginn
    {
        public int Id { get; set; }
        public string loginn{ get; set; }
        public string senha { get; set; }
        public IList<Funcionario> Funcionarios { get; set; }

        public Loginn()
        {
            Funcionarios = new List<Funcionario>();
        }

        public override string ToString()
        {
            return $"{Id} {loginn} {senha}";
        }
    }
}
