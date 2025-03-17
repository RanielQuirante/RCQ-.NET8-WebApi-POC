using System.ComponentModel.DataAnnotations;

namespace WebApiNet8POC.Models.Entities
{
    public class EmploymentEntity
    {
        public int Id { get; set; }

        [Required]
        public string? Company { get; set; }

        [Required]
        public uint? MonthsOfExperience { get; set; }

        [Required]
        public uint? Salary { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}