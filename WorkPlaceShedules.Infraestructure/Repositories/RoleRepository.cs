using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlaceShedules.Domain.Entities;
using WorkPlaceShedules.Domain.Repositories;
using WorkPlaceShedules.Infraestructure.Data;

namespace WorkPlaceShedules.Infraestructure.Repositories
{
    public class RoleRepository:GenericRepository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(DataContext dataContext) : base(dataContext) { }
    }
}
