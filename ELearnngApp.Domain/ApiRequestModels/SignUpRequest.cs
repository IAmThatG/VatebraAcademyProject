using System;
using System.ComponentModel.DataAnnotations;

namespace ELearnngApp.Domain.ApiRequestModels
{
    public class SignUpRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    }
}
