using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace biydaalt.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string author { get; set; }
        public int page_count { get; set; }
        [ForeignKey("turulId")]
        public int turulId { get; set; }
        public virtual Turul turuluud { get; set; }
        [ForeignKey("dedTurulId")]
        public int dedTurulId { get; set; }
        public virtual Dedturul dedturuluud { get; set; }
        public int book_count { get; set; }
        [Column(TypeName = "date")]
        public DateOnly pub_date { get; set; }
        public string pub_company { get; set; }
        public int price { get; set; }
        [ForeignKey("workerId")]
        public int workerId { get; set; }
    }
}
