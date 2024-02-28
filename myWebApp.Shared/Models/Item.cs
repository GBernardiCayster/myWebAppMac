using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace myWebApp.Shared.Models
{
    [Table("Items")]           //Nome della Tabella nel DataBase... 

    public class Item {

        [Key]
        public int Id { get; set; }

        [Required]
        public bool Done { get; set; } = false;

        [Required]
        public string Text { get; set; } = string.Empty;
    }
}
