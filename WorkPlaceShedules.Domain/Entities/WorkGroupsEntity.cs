    using System.ComponentModel.DataAnnotations;

namespace WorkPlaceShedules.Domain.Entities
{
    public class WorkGroupsEntity
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupDescription { get; set; } = string.Empty;
        public string GroupName { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Modified { get; set; } = DateTime.Now;
        public string Creator { get; set; } = "admin";
        public string? Modifier { get; set; } = "admin";
    }
}
