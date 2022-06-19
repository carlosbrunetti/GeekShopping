using GeekShopping.OrderApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.OrderApi.Model
{
    [Table("OrderHeader")]
    public class OrderHeader : BaseEntity
    {
        [Column("UserId")]
        public string UserId { get; set; }

        [Column("CouponCode")]
        public string? CouponCode { get; set; }

        [Column("PurchaseAmount")]
        public decimal PurchaseAmount { get; set; }

        [Column("DiscountAmount")]
        public decimal DiscountAmount { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("PurchaseDate")]
        public DateTime DateTime { get; set; }

        [Column("OrderTime")]
        public DateTime OrderTime { get; set; }

        [Column("PhoneNumber")]
        public string Phone { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("CardNumber")]
        public string CardNumber { get; set; }

        [Column("Cvv")]
        public string CVV { get; set; }

        [Column("ExpiryMonthYear")]
        public string ExpiryMonthYear { get; set; }

        [Column("TotalItens")]
        public int CartTotalItens { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        [Column("PaymentStatus")]
        public bool PaymentStatus { get; set; }
    }
}
