using System;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]/")]
    public class ProductDetailController : Controller
    {
        private readonly IProductDetailService _productDetailService;
        private readonly ILoggerManager _loggerManager;
        public ProductDetailController(IProductDetailService productDetailService, ILoggerManager loggerManeger)
        {
            _loggerManager = loggerManeger;
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _productDetailService.Get();
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los product detail: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> GetProductDetails()
        {
            try
            {
                var query = await _productDetailService.GetDetails(); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los product detail: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = await _productDetailService.GetById(id); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener el product detail: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductDetailDto product)
        {
            try
            {
                _productDetailService.Save(product);
                return CreatedAtAction(nameof(GetById), new { idProduct = product.Id }, product);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error cuando se intentaba guardar el product detail: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var query = await _productDetailService.DeleteById(id);
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se eliminaba el product detail: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDetailDto product)
        {
            try
            {
                var query = await _productDetailService.Update(product); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se modificaba el product detail: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

    }
}