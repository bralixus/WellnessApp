using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class IdentityService
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Service")]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime Data { get; set; }
        
    }
}