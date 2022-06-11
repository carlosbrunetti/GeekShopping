using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.CouponApi.Migrations
{
    public partial class Apply_CouponSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "Id", "CouponCode", "DiscountAmount" },
                values: new object[] { 1L, "PROMO_2020_10", 10m });

            migrationBuilder.InsertData(
                table: "Coupon",
                columns: new[] { "Id", "CouponCode", "DiscountAmount" },
                values: new object[] { 2L, "PROMO_2022_15", 15m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupon",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Coupon",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
