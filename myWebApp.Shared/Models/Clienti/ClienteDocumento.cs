
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myWebApp.Shared.Models
{

    [Table("Clienti Documenti")]
    public partial class ClienteDocumento
    {

        [Required]
        [Column("Codice Cliente")]
        [StringLength(20)]
        public string CodiceCliente { get; set; } = string.Empty;

        [Required]
        [Column("ID Documento")]
        [StringLength(10)]
        public string IDDocumento { get; set; } = string.Empty;

        [Required]
        [StringLength(400)]
        [Column("Descrizione Documento")]
        public string DescrizioneDocumento { get; set; } = string.Empty;


        [StringLength(20)]
        [Column("Livello 1")]
        public string Livello1 { get; set; }

        [StringLength(20)]
        [Column("Livello 2")]
        public string Livello2 { get; set; } = string.Empty;

        [StringLength(20)]
        [Column("Livello 3")]
        public string Livello3 { get; set; } = string.Empty;

        [Column("Data Documento")]
        public DateTime DataDocumento { get; set; }

        [StringLength(400)]
        public string URL { get; set; } = string.Empty;



    }
}