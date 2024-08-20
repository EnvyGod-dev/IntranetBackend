namespace Intranet.Services.CouponAPI.Models.DTO
{
    public class CouponDTO
    {
        public int CouponId { get; set; }
        public string CouponName { get; set; }

        public string DiscountAmount { get; set; }

        public int DiscountAmountTotal { get; set; }
    }
}