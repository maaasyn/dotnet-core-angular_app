using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DattingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(255)]
        public string Username { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Zle haslo", MinimumLength = 4)]
        public string Password { get; set; }
    }
}
