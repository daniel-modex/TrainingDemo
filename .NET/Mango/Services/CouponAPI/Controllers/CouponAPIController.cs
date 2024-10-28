using AutoMapper;
using CouponAPI.Data;
using CouponAPI.Models;
using CouponAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CouponAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly ResponseDTO _response;

        public CouponAPIController(AppDbContext dbcontext, IMapper mapper, ResponseDTO response)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
            _response = response;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetCoupons()
        {
            var coupons = _mapper.Map<IEnumerable<CouponDTO>>(await _dbcontext.Coupons.ToListAsync());
            _response.Result = coupons;
            return Ok(_response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetCoupon(int id)
        {
            CouponDTO coupon = _mapper.Map<CouponDTO>(await _dbcontext.Coupons.FindAsync(id));
            _response.Result = coupon;
            return Ok(_response);
        }

        [HttpGet]
        public ResponseDTO GetResponses()
        {
            try
            {
                IEnumerable<Coupon> Objlist = _dbcontext.Coupons.ToList();
                _response.Result = Objlist;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> PostCoupon(CouponDTO couponDTO)
        {
            var coupon = _mapper.Map<Coupon>(couponDTO);
            _response.Result = coupon;
            _dbcontext.Add(coupon);
            await _dbcontext.SaveChangesAsync();
            return Ok(_response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDTO>> PutCoupon(int id, CouponDTO couponDTO)
        {
            Coupon? coupon = await _dbcontext.Coupons.FindAsync(id);
            coupon.CouponCode = couponDTO.CouponCode;
            coupon.DiscountAmount = couponDTO.DiscountAmount;
            coupon.MinAmount = couponDTO.MinAmount;
            await _dbcontext.SaveChangesAsync();
            _response.Result= coupon;
            return _response;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCoupon(int id)
        {
            Coupon? coupon = await _dbcontext.Coupons.FindAsync(id);
            if (coupon!=null)
            {
                _dbcontext.Coupons.Remove(coupon);
                await _dbcontext.SaveChangesAsync(); 
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
    }
}
