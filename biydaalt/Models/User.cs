using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }
        [Required(ErrorMessage = "Овогоо оруулна уу")]
        [DisplayName("Үйлчлүүлэгчийн овог")]
        public string userLast { get; set; }
        [Required(ErrorMessage = "Нэрээ оруулна уу")]
        [DisplayName("Үйлчлүүлэгчийн нэр")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Email-ээ оруулна уу")]
        [DisplayName("Үйлчлүүлэгчийн email")]
        public string email { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [MaxLength(10)]
        [MinLength(10)]
        [DisplayName("Регистер")]
        [Required(ErrorMessage = "Регистерийн дугаараа оруулна уу")]
        public string regdug { get; set; }
        public string password { get; set; }
    }
}
