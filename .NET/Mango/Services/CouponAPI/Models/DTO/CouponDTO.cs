namespace CouponAPI.Models.DTO
{
    public class CouponDTO
    {
       
        public string? CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
