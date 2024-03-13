
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace myWebApp.Shared.Models
{
    [Table("Categorie Clienti")]
    public partial class CategoriaClienti
    {
        [Key]
        [StringLength(36)]
        public string IDCategoria { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(50)]
        public string? Descrizione { get; set; }


    }



}