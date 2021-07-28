using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenKaiTsai.HotelManagementSystem.ApplicationCore.Entities
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(20)]
        public string NAME { get; set; }
        [StringLength(40)]
        public string EMAIL { get; set; }
        [MaxLength(1024)]
        public string HashedPassword { get; set; }
        [MaxLength(1024)]
        public string Salt{ get; set; }
    }
}
