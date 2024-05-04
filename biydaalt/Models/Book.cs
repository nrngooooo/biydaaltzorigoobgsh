using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int bookId { get; set; }
        [Required(ErrorMessage = "Номын нэрийг оруулна уу")]
        [DisplayName("Номын нэр")]
        public string bookName { get; set; }
        [DisplayName("Номын зураг")]
        public string bookimage { get; set; }
        [Required(ErrorMessage = "Зохиолчийн нэрийг оруулна уу")]
        [DisplayName("Зохиолч")]
        public string author { get; set; }
        [Required(ErrorMessage = "Хуудасны тоог оруулна уу")]
        [DisplayName("Хуудасны тоо")]
        public int page_count { get; set; }
        [ForeignKey("turulId")]
        public int turulId { get; set; }
        public virtual Turul turuluud { get; set; }
        [ForeignKey("dedTurulId")]
        public int dedTurulId { get; set; }
        public virtual Dedturul dedturuluud { get; set; }
        [Required(ErrorMessage = "Номын үлдэгдэл тоог оруулна уу")]
        [DisplayName("Номын тоо")]
        public int book_count { get; set; }
        [Column(TypeName = "date")]
        [DisplayName("Хэвлэгдсэн он")]
        public DateOnly pub_date { get; set; }
        [DisplayName("Хэвлэгдсэн компани")]
        public string pub_company { get; set; }
        [DisplayName("Номын үнэ")]
        public int price { get; set; }
        [ForeignKey("workerId")]
        public int workerId { get; set; }
        public virtual Worker worker { get; set; }

    }
}
