using System.ComponentModel.DataAnnotations;

namespace EmployeeManagerApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Department { get; set; }

        [Required]
        public string Role { get; set; } = string.Empty;

        public int LeaveBalance { get; set; }

     
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}