using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceShedules.Application.Model.Users;
using WorkPlaceShedules.Application.Model.WorkGroups;
using WorkPlaceShedules.Application.Model.WorkPlaces;
using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Application.Model.WorkPlaceShedules
{
    public class UserWorkPlaceShedulesResponseModel
    {
        [Key]
        public int UserWorkPlaceScheduleId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime Schedule { get; set; }
        public bool IsAdminRequest { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        public string Creator { get; set; } = "admin";
        public string Modifier { get; set; } = "admin";
    }
}
