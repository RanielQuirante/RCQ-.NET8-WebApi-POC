namespace WebApiNet8POC.Models.Dtos.Request
{
    public class EmploymentRequestDto
    {
        public string? Company { get; set; }
        public uint? MonthsOfExperience { get; set; }
        public uint? Salary { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int UserId { get; set; }
    }
}