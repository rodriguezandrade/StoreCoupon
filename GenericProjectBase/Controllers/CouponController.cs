
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
using Store.Coupon.Web;

namespace GenericProjectBase.Controllers
{

    [Route("api/v{version:apiVersion}/[Controller]/")]
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
        public async Task<IActionResult> Add([FromBody] CouponDto coupon)
        {
            try
            {
                _couponService.Create(coupon);
                // ReSharper disable once Mvc.ActionNotResolved

                return CreatedAtAction(nameof(GetById), new { idCoupon = coupon.Id }, coupon);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error cuando se intentaba guardar el cupon: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }

        }

        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> GetCouponDetails()
        {
            try
            { 
                return Ok(await _couponService.GetDetails());
            } 
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los cupones: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _couponService.Get();
                return Ok(await _couponService.Get());
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los cupones: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _couponService.FindByCondition(id));
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener el coupon: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                return Ok(await _couponService.DeleteById(id));
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se eliminaba el coupon: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CouponDto coupon)
        {
            try
            { 
                return Ok(await _couponService.Update(coupon));
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se modificaba el coupon: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}