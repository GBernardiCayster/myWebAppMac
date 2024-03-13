
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace myWebApp.Shared.Models
{
    [Table("Condizioni Pagamento")]
    public partial class CondizionePagamento
    {
        [Key]
        [StringLength(36)]
        public string IDPagamento { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string? Descrizione { get; set; }


    }



}