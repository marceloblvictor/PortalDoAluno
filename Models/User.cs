using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDoAluno.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }
        
        public string Email { get; set; }
    }
}
