namespace StradaTechnicalInterview.Models.Dtos.Request
{
    public class UserRequestDto
    {
        public UserRequestDto()
        {
            Employments = new List<EmploymentRequestDto>();
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public AddressRequestDto? Address { get; set; }
        public List<EmploymentRequestDto> Employments { get; set; }
    }
}