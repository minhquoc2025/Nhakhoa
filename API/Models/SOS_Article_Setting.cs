using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[PrimaryKey("Article_Group_ID", "Article")]
public partial class SOS_Article_Setting
{
    [Required]
    [StringLength(4)]
    public string Season { get; set; }
    
    [StringLength(20)]
    public string Dev_Type { get; set; }
    [Required]
    [StringLength(10)]
    public string Upper_Tooling_Number { get; set; }
    [Required]
    [StringLength(10)]
    public string Outsole_Tooling_Number { get; set; }
    [Required]
    [StringLength(50)]
    public string Model { get; set; }
    [Required]
    [StringLength(50)]
    public string Model_Name { get; set; }
    [Required]
    [StringLength(20)]
    public string Gender { get; set; }
    [Key]
    [StringLength(50)]
    public string Article_Group_ID { get; set; }
    [Key]
    [StringLength(50)]
    public string Article { get; set; }
    [Required]
    [StringLength(1)]
    public string Special_Article { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime Update_Time { get; set; }
    [Required]
    [StringLength(50)]
    public string Update_By { get; set; }
}
