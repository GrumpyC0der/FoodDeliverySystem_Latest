using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem.Shared.Models
{
   public class Staff
    {
        public Staff()
        {
            this.Order = new HashSet<Order>();
        }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffContact { get; set; }
        public string StaffPostion { get; set; }

        public virtual ICollection<Order> Order { get; set; }

    }
}
