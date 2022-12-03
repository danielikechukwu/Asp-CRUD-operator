using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? Department { get; set; }
    }
}
