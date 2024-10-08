﻿using System.ComponentModel.DataAnnotations;

namespace Intranet.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public string CouponCode { get; set; }

        [Required]
        public string DiscountAmount { get; set; }

        [Required]
        public string MinAmount { get; set; }
    }
}
