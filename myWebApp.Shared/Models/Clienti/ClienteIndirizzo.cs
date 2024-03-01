
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myWebApp.Shared.Models
{

    [Table("Clienti Indirizzi")]
    public partial class ClienteIndirizzo
    {

        [Required]
        [Key]
        [Column("Codice Cliente")]
        public string CodiceCliente { get; set; } = string.Empty;

        [Required]
        [Column("Codice Indirizzo")]
        public string CodiceIndirizzo { get; set; } = string.Empty;

        [Required]
        [Column("Ragione Sociale")]
        public string RagioneSociale { get; set; } = string.Empty;


        public string? Indirizzo { get; set; }
        public string? CAP { get; set; }
        public string? Localita { get; set; }
        public string? Provincia { get; set; }
        public string? Telefono { get; set; }
        public string? EMail { get; set; }
    }
}