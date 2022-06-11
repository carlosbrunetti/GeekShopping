using GeekShopping.CoupnApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CouponApi.Model.Base
{
    [Table("Coupon")]
    public class Coupon : BaseEntity
    {
        [Column("CouponCode")]
        [Required]
        [StringLength(30)]
        public string CouponCode { get; set; }
        
        [Column("DiscountAmount")]
        [Required]
        public decimal DiscountAmount { get; set; }

    }
}
