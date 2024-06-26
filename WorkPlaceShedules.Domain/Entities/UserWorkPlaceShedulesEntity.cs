﻿using System.ComponentModel.DataAnnotations;

namespace WorkPlaceShedules.Domain.Entities
{
    public class UserWorkPlaceShedulesEntity
    {
        [Key]
        public int UserWorkPlaceScheduleId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Schedule { get; set; }
        [Required]
        public bool IsAdminRequest { get; set; } = false;
        [Required]
        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Modified { get; set; } = DateTime.Now;
        public string Creator { get; set; } = "admin";
        public string Modifier { get; set; } = "admin";

    }
}
