using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComViewAPI.Dto.User
{
    public class UserRegisterDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(36)]
        public string Username { get; set; }
        [MaxLength(36)]
        public string Name { get; set; }
        [MaxLength(36)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(36)]
        public string Password { get; set; }
    }
}
