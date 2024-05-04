using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class Torguulishaltgaan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int torguulishaltgaanId { get; set; }
        [DisplayName("Торгуулийн шалтгаан")]
        public string torguulishaltgaanName { get; set; }
    }
}
