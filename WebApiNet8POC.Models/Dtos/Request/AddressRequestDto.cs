namespace WebApiNet8POC.Models.Dtos.Request
{
    public class AddressRequestDto
    {
        public string? Street { get; set; }
        public string? City { get; set; }
        public int? PostCode { get; set; }
    }
}