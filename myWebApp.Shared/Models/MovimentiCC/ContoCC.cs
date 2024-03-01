
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myWebApp.Shared.Models
{
    [Table("Conti Correnti")]
    public partial class ContoCC
    {
        [Key]
        [StringLength(20)]
        [Column("Codice C/C")]
        public string Codice { get; set; } = string.Empty;


        [Required]
        [StringLength(50)]
        public string? Descrizione { get; set; }


        [Required]
        [StringLength(1)]
        public string Chiuso { get; set; } = "N";        //S=Si  N=No

        [StringLength(50)]
        public string? IBAN { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public string Default { get; set; } = "N";        //S=Si  N=No

    }



}