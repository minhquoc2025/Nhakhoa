using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class SOS_Sales_Order_Scheduling_Result
    {
        public int? Scheduling_Seq { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Scheduling_Date { get; set; }
        [StringLength(60)]
        public string SID { get; set; }
        [StringLength(60)]
        public string Factory3 { get; set; }
        [StringLength(60)]
        public string Factory_ID { get; set; }
        [Key]
        [StringLength(60)]
        public string Demand_Order_Header { get; set; }
        [Key]
        [StringLength(60)]
        public string Demand_Order_Batch_Number { get; set; }
        [Key]
        [StringLength(60)]
        public string Customer_Order_ID { get; set; }
        [Column(TypeName = "numeric(17, 4)")]
        public decimal? Batch_Qty { get; set; }
        [StringLength(8)]
        public string Predict_Deliver_Date { get; set; }
        [StringLength(8)]
        public string Promise_Deliver_Date { get; set; }
        [StringLength(8)]
        public string Due_Date { get; set; }
        [StringLength(8)]
        public string Order_Date { get; set; }
        [StringLength(60)]
        public string Generic_Material { get; set; }
        [StringLength(50)]
        public string Model_NO { get; set; }
        [StringLength(50)]
        public string Model_Name { get; set; }
        [StringLength(50)]
        public string Article { get; set; }
        [StringLength(1)]
        public string Special_Article { get; set; }
        [StringLength(50)]
        public string Article_Group_ID { get; set; }
        [StringLength(3)]
        public string Article_Group_Priority { get; set; }
        public int? Article_Group_Priority_Seq { get; set; }
        [StringLength(60)]
        public string Demand_Order_Type { get; set; }
        public int? Order_Type_Priority { get; set; }
        [StringLength(60)]
        public string Demand_Order_Remark { get; set; }
        [StringLength(60)]
        public string Customer_ID { get; set; }
        [StringLength(100)]
        public string Customer_Name { get; set; }
        [StringLength(60)]
        public string Ship_To_Customer_ID { get; set; }
        [StringLength(100)]
        public string Ship_To_Customer_Name { get; set; }
        [StringLength(100)]
        public string Ship_To_Customer_Country { get; set; }
        [StringLength(3)]
        public string Destination_Limit { get; set; }
        [StringLength(60)]
        public string Class_Code { get; set; }
        public int? Class_Code_Priority { get; set; }
        [StringLength(8)]
        public string Hold_Shipment { get; set; }
        [StringLength(8)]
        public string Plan_Date { get; set; }
        public int? Lead_Time { get; set; }
        [StringLength(200)]
        public string Priority { get; set; }
    }
}