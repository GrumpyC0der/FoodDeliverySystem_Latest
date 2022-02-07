using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Shared.Models
{
    public class FoodStores
    {
        public FoodStores()
        {
            this.Foods = new HashSet<Food>();
        }
        [Key]
        public int FoodStoresID { get; set; }
        public string FoodStoresName { get; set; }

        public string StoreArea { get; set; }
        public string StoreAddress { get; set; }
        public string FoodQuantity { get; set; }
        public virtual ICollection<Food> Foods { get; set; }


    }
}
