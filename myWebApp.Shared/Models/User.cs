
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myWebApp.Shared.Models
{
    [Table("Users")]
    public partial class User
    {

        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = "gbernardi@cayster.it";
        [Required]
        [StringLength(50)]
        public string Password { get; set; } = "yankee57_PWD";      //TODO must be encrypted

        [StringLength(50)]
        public string DataBaseName { get; set; } = "Giuliano";


        public string Role { get; set; } = "Administrator";



    }



}