
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{

    [Route("api/coupons/")]
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
                await _couponService.SaveChage();
                _loggerManager.LogInfo("Coupon guardado exitosamente");
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
                _loggerManager.LogInfo("Cupones se obtuvieron exitosamente");
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
                _loggerManager.LogInfo("Coupones se obtuvieron exitosamente");
                return Ok(query);
            } 
            catch(Exception e) 
            {
                _loggerManager.LogError("Ocurrio un error al obtener los cupones: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("get/{idCoupon}")]
        public async Task<IActionResult> GetById(Guid idCoupon) {
            try {
                var query = await _couponService.FindByCondition(idCoupon);
                _loggerManager.LogInfo("Coupon se obtuvo correctamente");
                return Ok(query);
            } catch (Exception e) {
                _loggerManager.LogError("Ocurrio un error al obtener el coupon: " + e);
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("delete/{idCoupon}")]
        public async Task<IActionResult> DeleteById(Guid idCoupon) {
            try { 
                var query = await _couponService.DeleteById(idCoupon);
                _loggerManager.LogInfo("El coupon fue eliminado correctamente");
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
                _loggerManager.LogInfo("El coupon fue modificado exitosamente");
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
