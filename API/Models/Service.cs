using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API.Models
{
    public class Service
    {
        public int service_id { get; set; }
        [StringLength(50)]
        public string service_name { get; set; }
        [StringLength(100)]
        public string service_describe { get; set; }
        
    }
}