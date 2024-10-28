using AutoMapper;
using CouponAPI.Models.DTO;

namespace CouponAPI.Models
{
    public class CouponMappingProfile: Profile
    {
        public CouponMappingProfile()
        {
            CreateMap<Coupon,CouponDTO>();
            CreateMap<CouponDTO,Coupon>();
        }
    }
}
