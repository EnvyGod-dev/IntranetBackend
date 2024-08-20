using Intranet.Services.CouponAPI.Data;
using Intranet.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.Services.CouponAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;


        public CouponAPIController(AppDbContext db)
        {
            _db = db;   
        }

        [HttpGet]
        public Object Get() {
            try
            {
                IEnumerable<Coupon> obList = _db.Coupons.ToList();
                return obList;
            }
            catch (Exception ex) { 
            }
            return null;
        }
    }
}
