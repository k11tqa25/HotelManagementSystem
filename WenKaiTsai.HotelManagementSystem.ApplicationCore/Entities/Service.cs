using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities
{
    [Table("Service")]
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Room")]
        public int? ROOMNO { get; set; }
        [StringLength(50)]
        public string SDESC { get; set; }
        [Column(TypeName = "money")]
        public decimal? AMOUNT { get; set; }
        public DateTime? SERVICEDATE { get; set; }

        public Room Room { get; set; }
    }
}
