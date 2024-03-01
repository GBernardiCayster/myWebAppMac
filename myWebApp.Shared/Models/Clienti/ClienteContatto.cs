
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myWebApp.Shared.Models
{

    [Table("Clienti Contatti")]
    public partial class ClienteContatto
    {

        [Required]
        [Column("Codice Cliente")]
        [StringLength(50)]
        public string CodiceCliente { get; set; } = string.Empty;

        [Required]
        [Column("Codice Contatto")]
        [StringLength(10)]
        public string CodiceContatto { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nominativo { get; set; } = string.Empty;


        [StringLength(50)]
        public string Ruolo { get; set; } = string.Empty;

        [StringLength(30)]
        public string Telefono { get; set; } = string.Empty;

        [StringLength(30)]
        public string Cellulare { get; set; } = string.Empty;

        [StringLength(50)]
        public string EMail { get; set; } = string.Empty;

        [StringLength(50)]
        public string SkyPe { get; set; } = string.Empty;

    }
}