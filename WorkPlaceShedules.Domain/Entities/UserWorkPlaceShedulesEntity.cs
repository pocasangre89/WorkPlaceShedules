using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceShedules.Domain.Entities
{
    public class UserWorkPlaceShedulesEntity
    {
        [Key]
        public int UserWorkPlaceScheduleId { get; set; }
        public DateTime Schedule { get; set; }
        public bool IsAdminRequest { get; set; } = false;
        public bool IsActive { get; set; } = true;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Modified { get; set; } = DateTime.Now;
        public string Creator { get; set; } = "admin";
        public string Modifier { get; set; } = "admin";

        public virtual UsersEntity UsersEntityP { get; set; } = new UsersEntity();
        public int UserId { get; set; }

        public virtual WorkPlacesEntity WorkPlacesP { get; set; } = new WorkPlacesEntity();
        public int WorkPlaceId { get; set; }

        public virtual WorkGroupsEntity WorkGroupP { get; set; } = new WorkGroupsEntity();
        public int GroupId { get; set; }
    }
}
