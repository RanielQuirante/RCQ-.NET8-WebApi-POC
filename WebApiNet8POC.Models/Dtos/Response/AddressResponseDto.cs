namespace WebApiNet8POC.Models.Dtos.Response
{
    public class AddressResponseDto
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public int? PostCode { get; set; }
    }
}