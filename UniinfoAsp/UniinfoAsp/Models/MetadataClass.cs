using System;
using System.ComponentModel.DataAnnotations;
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

        //[MaxLength(30)]
        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        //[Remote("computadorCadastrado", "Funcionario", ErrorMessage = "Esse computador ja está cadastrado")]
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

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public int idNivelAcesso { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        [System.Web.Mvc.Remote("loginExistente", "Loginn", ErrorMessage = "Login existente")]
        public string login { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string senha { get; set; }
    }

    [MetadataType(typeof(ChamadoMetadata))]
    public partial class Chamado
    {

    }

    public partial class ChamadoMetadata
    {
        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public int idFuncionario { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public int idProblema { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public System.DateTime dataChamado { get; set; }

        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public string statusAtendimento { get; set; }
    }

    [MetadataType(typeof(ProblemaMetadata))]
    public partial class Problema
    {

    }

    public partial class ProblemaMetadata
    {
        [Remote("problemaExistente", "Problema", ErrorMessage = "Problema existente")]
        [Required(ErrorMessage = "Campo vazio", AllowEmptyStrings = false)]
        public string tipoProblema { get; set; }
    }

}
