using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizzi.Models
{
    [Table("Login")]
    public class LoginInformations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        private string _password { get; set; }

        [Required]
        private string _token { get; set; }

        [Required]
        public int DetailsID { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
