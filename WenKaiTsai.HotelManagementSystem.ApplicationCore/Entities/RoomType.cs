using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities
{
    [Table("RoomType")]
    public class RoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(20)]
        public string RTDESC { get; set; }
        [Column(TypeName = "money")]
        public decimal? RENT { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
