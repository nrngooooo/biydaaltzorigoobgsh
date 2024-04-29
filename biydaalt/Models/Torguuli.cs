using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace biydaalt.Models
{
    public class Torguuli
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int torguuliId { get; set; }
        [ForeignKey("userId")]
        public int userId { get; set; }
        public virtual User user { get; set; }
        [ForeignKey("workerId")]
        public int workerId { get; set; }
        public virtual Worker worker { get; set; }
        [ForeignKey("bookId")]
        public int bookId { get; set; }
        public virtual Book book { get; set; }
        public int ashigodor { get; set; }
        public int torguulihemje { get; set; }
    }
}
