using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Shared.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderItemes = new HashSet<OrderItems>();
            this.Payments = new HashSet<Payment>();

        }
        public int OrderId { get; set; }
        public string OrderTime { get; set; }
        public string OrderFee { get; set; }
        public int StaffId { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public Staff Staff { get; set; }


        public virtual ICollection<OrderItems> OrderItemes { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }



    }
}
