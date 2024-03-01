
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myWebApp.Shared.Models
{
    [Table("Movimenti C/C")]
    public partial class MovimentoCC
    {
        [Key]
        public int ID { get; set; }


        [Required]
        [StringLength(20)]
        [Column("Codice C/C")]
        public string CodiceCC { get; set; } = string.Empty;


        [Required]
        [Column("Data Movimento")]
        public DateTime DataMovimento { get; set; }


        [Required]
        [StringLength(20)]
        public string Causale { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        [Column("Descrizione Movimento")]
        public string Descrizione { get; set; } = string.Empty;

        public Decimal Entrata { get; set; }

        public Decimal Uscita { get; set; }

        [NotMapped]
        public Decimal? Saldo { get; set; }




        [Required]
        [Column("Data Valuta")]
        public DateTime DataValuta { get; set; }

        [Required]
        [StringLength(1)]
        public string FVerificato { get; set; } = "S";        //S=Si   N=No


        [Required]
        [StringLength(1)]
        public string FTipoMov { get; set; } = "N";          //N=Normale   C=Carta di Credito

        [Required]
        [StringLength(1)]
        public string FScadenzario { get; set; } = "N";       //S=Si   N=No


    }




}