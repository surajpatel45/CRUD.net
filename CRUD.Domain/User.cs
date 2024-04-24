using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Domain
{
    public class User
    {
        public string Name { get; set; }
        [Key] public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
    }
}
