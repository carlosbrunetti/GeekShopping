using GeekShopping.OrderApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.OrderApi.Model
{
    [Table("OrderDetail")]
    public class OrderDetail : BaseEntity
    {
        public long OrderHeaderId { get; set; }
 
        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeader OrderHeader { get; set; }

        [Column("ProductId")]
        public long ProductId { get; set; }

        [Column("Count")]
        public int Count { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }
    }
}
