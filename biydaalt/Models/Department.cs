using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int departmentId { get; set; }
        [Required(ErrorMessage ="Хэлтэс нэмнэ үү")]
        [DisplayName("Хэлтэс")]
        public string departmentName { get; set; }
    }
}
