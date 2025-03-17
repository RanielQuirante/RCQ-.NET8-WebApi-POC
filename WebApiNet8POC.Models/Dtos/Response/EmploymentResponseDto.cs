namespace WebApiNet8POC.Models.Dtos.Response
{
    public class EmploymentResponseDto
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public uint? MonthsOfExperience { get; set; }
        public uint? Salary { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}