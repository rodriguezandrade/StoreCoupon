using System;
using System.Threading.Tasks;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/productDetails/")]
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
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _productDetailService.GetAll();
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los product detail: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetProductDtl()
        {
            try
            {
                var query = await _productDetailService.GetProducts(); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los product detail: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = await _productDetailService.GetById(id); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el product detail: " + e);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Add([FromBody] ProductDetailDto product)
        {
            try
            {
                _productDetailService.Save(product);
                return CreatedAtAction(nameof(GetById), new { idProduct = product.Id }, product);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el product detail: " + e);
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var query = await _productDetailService.DeleteById(id);
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el product detail:" + e);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] ProductDetailDto product)
        {
            try
            {
                var query = await _productDetailService.Update(product); 
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el product detail: " + e);
                return StatusCode(500);
            }
        }

    }
}