using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceShedules.Domain.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<UsersEntity> Users { get; set; }
    }
}
