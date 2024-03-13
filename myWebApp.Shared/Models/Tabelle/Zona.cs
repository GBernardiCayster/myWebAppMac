
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace myWebApp.Shared.Models
{
    [Table("Zone")]
    public partial class Zona
    {
        [Key]
        [StringLength(36)]
        public string IDZona { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string? Descrizione { get; set; }


    }



}