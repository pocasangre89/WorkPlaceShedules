using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceShedules.Domain.Entities;

namespace WorkPlaceShedules.Application.Model.WorkPlaceShedules
{
    public class UserWorkPlaceShedulesRequestModel
    {
        public int UserWorkPlaceScheduleId { get; set; }
        public DateTime Schedule { get; set; }
        public bool IsAdminRequest { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Creator { get; set; } = string.Empty;
        public string Modifier { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int WorkPlaceId { get; set; }
        public int GroupId { get; set; }
    }
}
