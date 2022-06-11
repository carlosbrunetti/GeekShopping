using GeekShopping.CartApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartApi.Model
{
    [Table("CartHeader")]
    public class CartHeader : BaseEntity
    {
        [Column("UserId")]
        public string UserId { get; set; }


        [Column("CouponCode")]
        public string? CouponCode { get; set; }
    }
}
