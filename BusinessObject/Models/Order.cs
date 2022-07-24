
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models
{
    public partial class Order : IEntityWithId
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Display(Name = "Order ID")]
        [Column("orderId")]
        public int Id { get; set; }
        [Display(Name = "Member ID")]
        public int? MemberId { get; set; }
        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }
        [Display(Name = "Required Date")]
        public DateTime? RequiredDate { get; set; }
        [Display(Name = "Shipped Date")]
        public DateTime? ShippedDate { get; set; }
        [Display(Name = "Freight")]
        public decimal? Freight { get; set; }
        [Display(Name = "Member")]
        public virtual Member? Member { get; set; }
        [Display(Name = "Order Details")]
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
