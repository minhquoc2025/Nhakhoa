using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Demo
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }
    }
}