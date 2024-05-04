using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class Actshaltgaan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int actshaltgaanId { get; set; }
        [DisplayName("Актласан шалтгаан")]
        public string actshaltgaanName { get; set; }
    }
}
