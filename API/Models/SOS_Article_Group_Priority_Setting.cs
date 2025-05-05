using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public partial class SOS_Article_Group_Priority_Setting
    {
        [Key]
        [StringLength(3)]
        public string Article_Group_Priority { get; set; }
        public int Article_Group_Priority_Seq { get; set; }
    }
}