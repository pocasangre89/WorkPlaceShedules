using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public DateTime Schedule { get; set; }
        public bool IsAdminRequest { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Creator { get; set; } = string.Empty;
        public string Modifier { get; set; } = string.Empty;

        public UsersResponseModel Users { get; set; }

        public WorkPlacesResponseModel WorkPlaces { get; set; }

        public WorkGroupsResponseModel WorkGroups { get; set; }
    }
}
