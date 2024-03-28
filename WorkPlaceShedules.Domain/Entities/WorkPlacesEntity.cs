using System.ComponentModel.DataAnnotations;

namespace WorkPlaceShedules.Domain.Entities
{
    public class WorkPlacesEntity
    {
        [Key]
        public int WorkPlaceId { get; set; }
        public string WorkPlaceCode { get; set; } = string.Empty;
        public string WorkPlaceName { get; set; } = string.Empty;
        public int WorkPlaceNumber { get; set; }
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
