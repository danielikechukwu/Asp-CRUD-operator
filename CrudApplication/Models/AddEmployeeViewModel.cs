using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.Models
{
    public class AddEmployeeViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }


        [Column(TypeName = "nvarchar(12)")]
        public double Salary { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? Department { get; set; }
    }
}
