
using System;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Logger.Interface;
using Core.Services.Interfaces; 
using Microsoft.AspNetCore.Mvc; 
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{

    [Route("api/v{version:apiVersion}/coupons/")]
    public class CouponController : Controller
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService, IMapper mapper, ILoggerManager loggerManager)
        {
            _loggerManager = loggerManager;
            _couponService = couponService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Add([FromBody] CouponDto coupon) {
            
            try
            {
                _couponService.create(coupon); 
                return CreatedAtAction(nameof(GetById), new { idCoupon = coupon.Id }, coupon);
            }
            catch(Exception e)
            {
                StringBuilder msg = new StringBuilder("Ocurrio un error cuando se intentaba guardar el cuopon: " + e);
                _loggerManager.LogError(msg.ToString());
                return StatusCode(500);
            }
            
        }
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetCoupons() {
            try {
                var query = await _couponService.GetCoupons(); 
                return Ok(query);
            } catch(Exception e) {
                _loggerManager.LogError("Ocurrio un error al obtener los cupones: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get() {
            try {
                var query = await _couponService.FindAll(); 
                return Ok(query);
            } 
            catch(Exception e) 
            {
                _loggerManager.LogError("Ocurrio un error al obtener los cupones: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(Guid id) {
            try {
                var query = await _couponService.FindByCondition(id); 
                return Ok(query);
            } catch (Exception e) {
                _loggerManager.LogError("Ocurrio un error al obtener el coupon: " + e);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteById(Guid id) {
            try { 
                var query = await _couponService.DeleteById(id);
                return Ok(query);
            } catch (Exception e) {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el coupon: " + e);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] CouponDto coupon) {
            try
            {
                var query = await _couponService.Modify(coupon);
                return Ok(query);
            }
            catch(Exception e) 
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el coupon: "+e);
                return StatusCode(500);
            }
        }
    }
}
