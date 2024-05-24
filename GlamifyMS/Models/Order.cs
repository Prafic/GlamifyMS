using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }


        public int UserId { get; set; }
     /*   [ForeignKey("UserId")]
        public User User { get; set; }*/
        public int TotalAmount { get; set; }

        public int ShippingCharge { get; set; } = 40;

        public int NetAmount { get; set; }

    }
}
