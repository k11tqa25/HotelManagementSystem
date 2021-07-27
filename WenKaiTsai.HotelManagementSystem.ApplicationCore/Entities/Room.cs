using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities
{
    [Table("Room")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("RoomType")]
        public int? RTCODE { get; set; }
        public bool? STATUS { get; set; }

        public RoomType RoomType { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Service> Services { get; set; }

    }
}
