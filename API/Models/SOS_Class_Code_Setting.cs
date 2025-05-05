using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class SOS_Class_Code_Setting
    {
        [Key]
        [StringLength(2)]
        public string Class_Code { get; set; }
        public int Class_Code_Priority { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Update_Time { get; set; }
        [Required]
        [StringLength(50)]
        public string Update_By { get; set; }
    }
}