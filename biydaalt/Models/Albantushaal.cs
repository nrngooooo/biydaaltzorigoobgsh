using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace biydaalt.Models
{
    public class Albantushaal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int albantushaalId { get; set; }
        [DisplayName("Албан тушаал")]
        public string albantushaalName { get; set; }
    }
}
