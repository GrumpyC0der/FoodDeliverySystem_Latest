using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Shared.Models
{
    public class OrderItems
    {
        public int OrderItemsId { get; set; }
        public string OrderQuantity { get; set; }
        public int FoodID { get; set; }

        public Food Food { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }




    }
}
