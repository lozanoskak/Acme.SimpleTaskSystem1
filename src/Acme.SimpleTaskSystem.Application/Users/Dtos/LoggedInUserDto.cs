using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskSystem.Users.Dtos
{
    public class LoggedInUserDto
    {
        public int? Id { get; set; }
        public int Role { get; set; }
    }
}
