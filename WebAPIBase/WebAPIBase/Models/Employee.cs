using System.ComponentModel.DataAnnotations;

namespace WebAPIBase.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20,ErrorMessage = "FirstName length cannot exceed 20")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "LastName length cannot exceed 20")]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Designation length cannot exceed 20")]
        public string Designation { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}
