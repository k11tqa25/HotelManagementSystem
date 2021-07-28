using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Models
{
    public class AdminRegisterRequestModel
    {
        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The passowrd should be minimum of 8 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&-]).{8,}$",
            ErrorMessage = "Password should have minimun og 8 characters and should include one upper, lower, number and a special char")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(64)]
        public string Email { get; set; }
    }
}
