using System;

using System.Threading.Tasks;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/productdetails/")]
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
                _loggerManager.LogInfo("ProductDtl se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los productsDtl: " + e);
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
                _loggerManager.LogInfo("ProductDtl se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los productsDtl: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("get/{idProduct}")]
        public async Task<IActionResult> GetById(Guid idProduct)
        {
            try
            {
                var query = await _productDetailService.GetById(idProduct);
                _loggerManager.LogInfo("ProductDtl se obtuvo correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el productDtl: " + e);
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
                await _productDetailService.SaveChanges();
                _loggerManager.LogInfo("ProductDtl guardado exitosamente");
                return CreatedAtAction(nameof(GetById), new { idProduct = product.Id }, product);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el productDtl: " + e);
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("delete/{idProduct}")]
        public async Task<IActionResult> DeleteById(Guid idProduct)
        {
            try
            {
                var query = await _productDetailService.DeleteById(idProduct);
                _loggerManager.LogInfo("El productDtl fue eliminado correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el productDtl: " + e);
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
                _loggerManager.LogInfo("El productDtl fue modificado exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el productDtl: " + e);
                return StatusCode(500);
            }
        }

    }
}