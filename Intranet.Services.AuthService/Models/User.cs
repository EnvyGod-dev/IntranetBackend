using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intranet.Services.AuthService.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }
    }
}
