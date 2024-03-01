
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
        [StringLength(20)]
        public string Codice { get; set; } = string.Empty;

        [Required]
        [Column("Ragione Sociale")]
        [StringLength(50)]
        public string RagioneSociale { get; set; } = "";


        [StringLength(50)]
        public string? Indirizzo { get; set; }


        [Column("CAP")]
        [StringLength(6)]
        public string? Cap { get; set; }


        [StringLength(50)]
        public string? Localita { get; set; }

        [StringLength(4)]
        public string? Provincia { get; set; }


        [Column("Partita IVA")]
        [StringLength(11)]
        public string? PartitaIva { get; set; }
        [Column("Codice Fiscale")]
        [StringLength(16)]
        public string? CodiceFiscale { get; set; }
        [StringLength(30)]
        public string? Telefono { get; set; }
        [Column("EMail")]

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(50)]
        [Required]
        public string Pagamento { get; set; } = string.Empty;

        [StringLength(50)]
        [Column("Categoria Cliente")]
        [Required]
        public string CategoriaCliente { get; set; } = string.Empty;

        [StringLength(50)]
        [Required]
        public string Zona { get; set; } = string.Empty;

        [StringLength(20)]
        [Required]
        public string Agente { get; set; } = string.Empty;


        [StringLength(35)]
        [Required]
        public string Listino { get; set; } = string.Empty;

        [StringLength(128)]
        public string? PEC { get; set; }

        [StringLength(7)]
        public string? CodiceSDI { get; set; }
    }



}