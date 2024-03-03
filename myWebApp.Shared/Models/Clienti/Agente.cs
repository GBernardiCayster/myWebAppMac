
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
        [Column("Ragione Sociale"),MaxLength(50)]
        public string RagioneSociale { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Indirizzo { get; set; }

        [MaxLength(6)]
        public string? CAP { get; set; }

        [MaxLength(50)]
        public string? Localita { get; set; }

        [MaxLength(4)]
        public string? Provincia { get; set; }

        [Column("Partita IVA"),MaxLength(11)]
        public string? PartitaIVA { get; set; }

        [Column("Codice Fiscale"),MaxLength(16)]
        public string? CodiceFiscale { get; set; }

        [MaxLength(30)]
        public string? Telefono { get; set; }

        [MaxLength(50)]
        public string? EMail { get; set; }
        
    }
}

