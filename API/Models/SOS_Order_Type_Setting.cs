using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class SOS_Order_Type_Setting
    {
        [Key]
        [StringLength(4)]
        public string Order_Type { get; set; }

        [Key]
        [StringLength(50)]
        public string Order_Type_Desc { get; set; }
        public int? Order_Type_Priority { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Update_Time { get; set; }
        [StringLength(50)]
        public string Update_By { get; set; }
    }
}