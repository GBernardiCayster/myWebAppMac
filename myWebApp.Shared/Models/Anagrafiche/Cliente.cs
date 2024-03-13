
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myWebApp.Shared.Models
{
    [Table("Clienti")]
    public partial class Cliente
    {
        [Key]
        [StringLength(36)]
        public string IDCliente { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [Column("Ragione Sociale")]
        [StringLength(50)]
        public string RagioneSociale { get; set; } = "";


        [StringLength(50)]
        public string? Indirizzo { get; set; }


        [StringLength(6)]
        public string? CAP { get; set; }


        [StringLength(50)]
        public string? Localita { get; set; }

        [StringLength(4)]
        public string? Provincia { get; set; }


        [Column("Partita IVA")]
        [StringLength(11)]
        public string? PartitaIVA { get; set; }
        [Column("Codice Fiscale")]
        [StringLength(16)]
        public string? CodiceFiscale { get; set; }
        [StringLength(30)]
        public string? Telefono { get; set; }
        [Column("EMail")]

        [StringLength(50)]
        public string? EMail { get; set; }

        [StringLength(36)]
        [Required]
        public string IDPagamento { get; set; } = string.Empty;

        [StringLength(36)]
        [Required]
        public string IDCategoria { get; set; } = string.Empty;

        [StringLength(36)]
        [Required]
        public string IDZona { get; set; } = string.Empty;

        [StringLength(36)]
        [Required]
        public string IDAgente { get; set; } = string.Empty;


        [StringLength(36)]
        [Required]
        public string IDListino { get; set; } = string.Empty;

        [StringLength(128)]
        public string? PEC { get; set; }

        [StringLength(7)]
        public string? CodiceSDI { get; set; }
    }



}