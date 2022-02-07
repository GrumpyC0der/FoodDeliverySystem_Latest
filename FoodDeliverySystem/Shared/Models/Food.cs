using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Shared.Models
{
    public class Food
    {

        public Food()
        {
            this.OrderItems = new HashSet<OrderItems>();
        }
        [Key]
        public int FoodID { get; set; }
        public string FoodPrice { get; set; }
        public string Description { get; set; }
        public int FoodStoresID { get; set; }

        public FoodStores FoodStores { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }


    }
}
