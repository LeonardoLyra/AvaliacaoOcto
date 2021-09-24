using System.ComponentModel.DataAnnotations;

namespace prova_Octo.Models
{
    public class Telefone
    {

        public int IdTelefone { get; set; }

        [Display(Name = "Tipo Telefone")]
        [Required(ErrorMessage = " Campo Obrigatório")]
        public string TipoTelefone { get; set; }

        [Display(Name = "Numero Telefone")]
        [Required(ErrorMessage = " Campo Obrigatório")]
        [DataType(DataType.PhoneNumber)]
        public string NumeroTelefone { get; set; }

        #region Dados do Cliente
        public int IdCliente { get; set; }
        #endregion
    }
}