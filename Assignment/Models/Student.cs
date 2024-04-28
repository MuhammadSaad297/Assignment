using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string Roll_Number { get; set; }
        [Required]
        public string Class   { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
    }
}
