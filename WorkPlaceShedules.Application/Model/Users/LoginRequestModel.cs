using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceShedules.Application.Model.Users
{
    public class LoginRequestModel
    {
        public required string Email {  get; set; }
        public required string Password { get; set; }
    }
}
