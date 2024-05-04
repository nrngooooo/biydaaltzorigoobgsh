using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace biydaalt.Models
{
    public class Bookgive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookgiveId { get; set; }
        [ForeignKey("bookId")]
        public int bookId { get; set; }
        public virtual Book book { get; set; }
        [ForeignKey("userId")]
        public int userId { get; set; }
        public virtual User user { get; set; }
        [ForeignKey("workerId")]
        public int workerId { get; set; }
        public virtual Worker worker { get; set; }
        [Column(TypeName = "date")]
        [DisplayName("Ном авсан огноо")]
        public DateOnly enterdate { get; set; }
        [Column(TypeName = "date")]
        [DisplayName("Ном буцааж өгсөн огноо")]
        public DateOnly retdate { get; set; }
    }
}
