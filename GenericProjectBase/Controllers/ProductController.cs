using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/product/")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILoggerManager _loggerManager;

        public ProductController(IProductService productService,ILoggerManager loggerManager)
        {
            _productService = productService;
            _loggerManager = loggerManager;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _productService.GetAll();
                _loggerManager.LogInfo("Productos se obtuvieron exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener los productos: " + e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("get/{idProduct}")]
        public async Task<IActionResult> GetById(Guid idProduct)
        {
            try
            {
                var query = await _productService.GetById(idProduct);
                _loggerManager.LogInfo("Producto se obtuvo correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error al obtener el producto: " + e);
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Add([FromBody] ProductDto producto)
        {
            try
            {
                _productService.Save(producto);
                await _productService.SaveChanges();
                _loggerManager.LogInfo("Producto guardado exitosamente");
                return CreatedAtAction(nameof(GetById), new { idProducto = producto.Id }, producto);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error cuando se intentaba guardar el producto: " + e);
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("delete/{idProduct}")]
        public async Task<IActionResult> DeleteById(Guid idProduct)
        {
            try
            {
                var query = await _productService.DeleteById(idProduct);
                _loggerManager.LogInfo("El producto fue eliminado correctamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se eliminaba el producto: " + e);
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] ProductDto producto)
        {
            try
            {
                var query = await _productService.Update(producto);
                _loggerManager.LogInfo("El producto fue modificado exitosamente");
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError("Ocurrio un error mientras se modificaba el producto: " + e);
                return StatusCode(500);
            }
        }
    }
}