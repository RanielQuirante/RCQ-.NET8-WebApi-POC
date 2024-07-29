using System.ComponentModel.DataAnnotations;

namespace StradaTechnicalInterview.Models.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }

        [Required]
        public string? Street { get; set; }

        [Required]
        public string? City { get; set; }

        public int? PostCode { get; set; }

        public int UserId { get; set; }
        public UserEntity? User { get; set; }
    }
}