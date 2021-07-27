using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Room")]
        public int? ROOMNO { get; set; }
        [StringLength(20)]
        public string CNAME { get; set; }
        [StringLength(100)]
        public string ADDRESS { get; set; }
        [StringLength(40)]
        public string EMAIL { get; set; }
        public DateTime? CHECKIN { get; set; }
        public int? TOTALPERSONS { get; set; }
        public int? BOOKINGDAYS { get; set; }
        [Column(TypeName = "money")]
        public decimal? ADVANCE { get; set; }

        public Room Room { get; set; }
    }
}
