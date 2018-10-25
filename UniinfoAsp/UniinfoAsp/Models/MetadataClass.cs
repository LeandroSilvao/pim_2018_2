using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniinfoAsp.Models
{
    [MetadataType(typeof(FuncionarioMetadata))]
    public partial class Funcionario
    {

    }
    public partial class FuncionarioMetadata
    {
        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public int idFuncionario { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public Nullable<int> ramal { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        //[Remote("nComputadorDisponivel", "Manage", ErrorMessage = "Esse computador ja está cadastrado")]
        public Nullable<int> nComputador { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public string setor { get; set; }
    }

    [MetadataType(typeof(LoginnMetadata))]
    public partial class Loginn
    {

    }

    public partial class LoginnMetadata
    {
        public string login { get; set; }
        [DataType(DataType.Password)]
        public string senha { get; set; }
    }
}
