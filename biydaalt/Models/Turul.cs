using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class Turul
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int turulId { get; set; }
        [Required(ErrorMessage ="Төрөл нэмнэ үү")]
        [DisplayName("Номын төрөл")]
        public string turulName { get; set; }
    }
}
