using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class Dedturul
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dedTurulId { get; set; }
        [Required(ErrorMessage = "Дэд төрөл нэмнэ үү")]
        [DisplayName("Номын дэд төрөл")]
        public string dedTurulName { get; set; }
        [ForeignKey("turulId")]
        public int turulId { get; set; }
        public virtual Turul turul { get; set; }
    }
}
