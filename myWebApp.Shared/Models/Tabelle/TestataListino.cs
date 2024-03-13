
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace myWebApp.Shared.Models
{
    [Table("Listini Testate")]
    public partial class TestataListino
    {
        [Key]
        [StringLength(36)]
        public string IDListino { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string? Descrizione { get; set; }

        [Column("Riferimento Listino")]
        [StringLength(36)]
        public string? RiferimentoListino { get; set; }

        public decimal  Percentuale { get; set; }

        [Required]
        public string Tipo { get; set; } = "V";    

    }



}