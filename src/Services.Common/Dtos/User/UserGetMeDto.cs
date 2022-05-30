using Services.Common.Dtos.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Dtos.User
{
    public class UserGetMeDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
