using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace biydaalt.Models
{
    public class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int workerId { get; set; }
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
        public string regdug { get; set; }
        public int phone { get; set; }
    }
}
