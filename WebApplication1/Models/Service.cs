using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{               
    public class Service
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<IdentityService> IdentityServices { get; set; }
        
    }
}