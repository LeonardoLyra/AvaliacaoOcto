using System.ComponentModel.DataAnnotations;

namespace prova_Octo.Models
{
    public class Endereco
    {
        public int IdEndereco { get; set; }

        [Display(Name = "Tipo Endereço")]
        [Required(ErrorMessage = " Campo Obrigatório")]
        public string TipoEndereco {get; set;}

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = " Campo Obrigatório")]
        public string Logradouro { get; set; }

        #region Dados do Cliente
        public int IdCliente { get; set; }
        #endregion
    }
}