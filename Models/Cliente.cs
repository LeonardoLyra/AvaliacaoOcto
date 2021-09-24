using System;
using System.ComponentModel.DataAnnotations;

namespace prova_Octo.Models
{
    public class Cliente
    {
        public int? IdCliente { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(6)]
        public string Nome { get; set; }

        [Display(Name = "TipoCliente")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string TipoCliente { get; set; }

        [Display(Name = "CPF_CNPJ")]
        [Required(ErrorMessage = " Campo Obrigatório")]
        [DisplayFormat(DataFormatString = "cpfBR")]
        public string CPF_CNPJ {get; set;}

    }
}