//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniinfoAsp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Loginn
    {
        [Display(Name = "Login Id")]
        public int idLogin { get; set; }
        [Display(Name = "Funcionario Id")]
        public int idFuncionario { get; set; }
        [Display(Name = "Login")]
        public string login { get; set; }
        [Display(Name = "Senha")]
        public string senha { get; set; }
        [Display(Name = "Nivel de Acesso")]
        public int idNivelAcesso { get; set; }
    
        public virtual Funcionario Funcionario { get; set; }
        public virtual nivelAcesso nivelAcesso { get; set; }
    }
}
