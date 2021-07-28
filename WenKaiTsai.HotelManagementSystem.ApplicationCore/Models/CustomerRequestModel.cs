using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Models
{
    public class CustomerRequestModel
    {
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(40)]
        public string Email { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public int TotalPerson { get; set; }
        [Required]
        public int BookingDays { get; set; }
        public decimal Advance { get; set; }
    }
}
