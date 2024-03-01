
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myWebApp.Shared.Models
{

    [Table("Agenti")]
    public partial class Agente
    {

        [Required]
        [Key]
        public string IDAgente { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Column("Ragione Sociale")]
        public string RagioneSociale { get; set; } = string.Empty;

        public string? Indirizzo { get; set; }
        public string? CAP { get; set; }
        public string? Localita { get; set; }
        public string? Provincia { get; set; }

        [Column("Partita IVA")]
        public string? PartitaIVA { get; set; }

        [Column("Codice Fiscale")]
        public string? CodiceFiscale { get; set; }
        public string? Telefono { get; set; }
        public string? EMail { get; set; }
    }
}