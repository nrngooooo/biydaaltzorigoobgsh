using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int workerId { get; set; }
        [Required(ErrorMessage = "Ажилтны нэрийг оруулна уу")]
        [DisplayName("Ажилтны нэр")]
        public string workerName { get; set; }
        [ForeignKey("departmentId")]
        public int departmentId { get; set; }
        public virtual Department department { get; set; }
        public int albantushaalId { get; set; }
        [ForeignKey("albantushaalId")]
        public virtual Albantushaal albantushaal { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [MaxLength(10)]
        [MinLength(10)]
        [DisplayName("Регистер")]
        [Required(ErrorMessage = "Регистерийн дугаараа оруулна уу")]
        public string regdug { get; set; }
        [MaxLength(8)]
        [MinLength(8)]
        [DisplayName("Утас")]
        [Required(ErrorMessage = "Утасны дугаараа оруулна уу")]
        public int phone { get; set; }
    }
}
