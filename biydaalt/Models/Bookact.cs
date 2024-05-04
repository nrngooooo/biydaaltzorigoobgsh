using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class Bookact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookactId { get; set; }
        [ForeignKey("bookId")]
        public int bookId { get; set; }
        public virtual Book book { get; set; }
        [ForeignKey("workerId")]
        public int workerId { get; set; }
        public virtual Worker worker { get; set; }
        [DisplayName("Актласан тоо")]
        public int act_count { get; set; }
        [ForeignKey("actshaltgaanId")]
        public int actshaltgaanId { get; set; }
        public virtual Actshaltgaan actshaltgaan { get; set;}
        [DisplayName("Актласан огноо")]
        [Column(TypeName = "date")]
        public DateOnly actdate { get; set; }
    }
}
