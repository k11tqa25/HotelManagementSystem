using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Models
{
    public class AdminLoginRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(64)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The passowrd should be minimum of 8 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
