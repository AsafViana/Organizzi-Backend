using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizzi.Models
{
    [Table("Services")]
    public class Services
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Time { get; set; }

        [Required]
        public string MaterialList { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
