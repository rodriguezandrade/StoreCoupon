
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Exceptions;
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
        public async Task<IActionResult> Add([FromBody] CouponDto coupon)
        {

            try
            {
                _couponService.create(coupon);
                return CreatedAtAction(nameof(GetById), new { idCoupon = coupon.Id }, coupon);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error cuando se intentaba guardar el cupon: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }

        }
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetCoupons()
        {
            try
            { 
                return Ok(await _couponService.GetCoupons());
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los cupones: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _couponService.FindAll());
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los cupones: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            { 
                return Ok(await _couponService.FindByCondition(id));
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el coupon: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            { 
                return Ok(await _couponService.DeleteById(id));
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el coupon: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] CouponDto coupon)
        {
            try
            {
                var query = await _couponService.Modify(coupon);
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el coupon: " + e);
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}
