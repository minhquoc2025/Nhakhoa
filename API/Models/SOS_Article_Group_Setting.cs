using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class SOS_Article_Group_Setting
{
    [Key]
    [StringLength(50)]
    public string Article_Group_ID { get; set; }
    [Required]
    [StringLength(3)]
    public string Article_Group_Priority { get; set; }
    [Required]
    [StringLength(50)]
    public string Primary_Category { get; set; }
    [Required]
    [StringLength(50)]
    public string Primary_Category_Desc { get; set; }
    [Required]
    [StringLength(50)]
    public string Secondary_Category { get; set; }
    [Required]
    [StringLength(50)]
    public string Secondary_Category_Desc { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime Update_Time { get; set; }
    [Required]
    [StringLength(50)]
    public string Update_By { get; set; }
}
