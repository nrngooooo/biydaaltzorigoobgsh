using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace biydaalt.Models
{
    public class Turul
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int turulId { get; set; }
        public string turulName { get; set; }
    }
}
