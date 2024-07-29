namespace StradaTechnicalInterview.Models.Dtos.Response
{
    public class UserResponseDto
    {
        public UserResponseDto()
        {
            Employments = new List<EmploymentResponseDto>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public AddressResponseDto? Address { get; set; }
        public List<EmploymentResponseDto> Employments { get; set; }
    }
}