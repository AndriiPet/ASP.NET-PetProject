using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class OrderDto
    {
        public int UserID { get; set; }
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderCost { get; set; }
        [StringLength(1000)]
        public string ItemsDescription { get; set; }
        [StringLength(1000)]
        public string ShippingAddress { get; set; }
    }
}
