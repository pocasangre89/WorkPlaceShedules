using System.ComponentModel.DataAnnotations;

namespace WorkPlaceShedules.Domain.Entities
{
    public class UsersEntity
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserCode { get; set; } = string.Empty;
        [Required]
        [MaxLength(200)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        public bool IsAdmin { get; set; } = false;
        public string Password {  get; set; } = string.Empty;
        [Required]
        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; } = DateTime.Now;
        public string Creator { get; set; } = "admin";
        public string? Modifier { get; set; }
        public int?  RoleId { get; set; }
        public RoleEntity? Role { get; set; }

    }
}
