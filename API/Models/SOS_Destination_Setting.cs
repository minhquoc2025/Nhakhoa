using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class SOS_Destination_Setting
    {
        [Key]
        [StringLength(50)]
        public string Destination { get; set; }
        [Required]
        [StringLength(3)]
        public string Destination_Limit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Update_Time { get; set; }
        [Required]
        [StringLength(50)]
        public string Update_By { get; set; }
    }
}