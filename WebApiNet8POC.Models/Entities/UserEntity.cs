using System.ComponentModel.DataAnnotations;

namespace WebApiNet8POC.Models.Entities
{
    public class UserEntity
    {
        public UserEntity()
        {
            Employments = new List<EmploymentEntity>();
        }

        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        public AddressEntity? Address { get; set; }

        public List<EmploymentEntity> Employments { get; set; }
    }
}