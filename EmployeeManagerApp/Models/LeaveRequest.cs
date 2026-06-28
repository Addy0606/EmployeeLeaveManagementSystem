using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagerApp.Models
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveRequestId { get; set; }

        public int EmployeeId { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(500)]
        public string? Reason { get; set; }

        [Required]
        public string Status { get; set; } = "Pending";

        [MaxLength(500)]
        public string? ManagerComment { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

        [ForeignKey("LeaveTypeId")]
        public LeaveType? LeaveType { get; set; }
    }
}
