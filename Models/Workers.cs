using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizzi.Models
{
    [Table("Workers")]
    public class Workers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<int> LocationsList { get; set; }

        [Required]
        public List<int> ServicesList { get; set; }

        [Required]
        public string Level {  get; set; }

        [Required]
        public int LoginID { get; set; }
    }
}
