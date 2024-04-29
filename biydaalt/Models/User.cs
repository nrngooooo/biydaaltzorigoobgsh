using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace biydaalt.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        public string userName { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [MaxLength(10)]
        [MinLength(10)]
        public string regdug { get; set; }
        public int phone { get; set; }
    }
}
