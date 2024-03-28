    using System.ComponentModel.DataAnnotations;

namespace WorkPlaceShedules.Domain.Entities
{
    public class WorkGroupsEntity
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        public string GroupDescription { get; set; } = string.Empty;
        [Required]
        public string GroupName { get; set; } = string.Empty;
        [Required]
        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; } = DateTime.Now;
        public string Creator { get; set; } = "admin";
        public string? Modifier { get; set; } = "admin";
    }
}
