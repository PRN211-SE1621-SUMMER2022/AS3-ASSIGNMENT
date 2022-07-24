using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public partial class Product : IEntityWithId
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Column("productId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product ID")]
        public int Id { get; set; }
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Weight")]
        public string Weight { get; set; }
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Units In Stock")]
        public int UnitsInStock { get; set; }
        [Display(Name = "Order Details")]

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
