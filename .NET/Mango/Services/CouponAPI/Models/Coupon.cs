﻿using System.ComponentModel.DataAnnotations;

namespace CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponID { get; set; }
        [Required]
        public string? CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }

    }
}
