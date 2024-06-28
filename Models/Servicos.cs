using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizzi.Models
{
    [Table("Servico")]
    public class Servicos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Tempo { get; set; }
        [Required]
        public List<int> ListaMateriais { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
