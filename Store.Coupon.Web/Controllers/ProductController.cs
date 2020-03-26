using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Models.Dtos;
using Store.Coupon.Web;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/products/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILoggerManager _loggerManager;

        public ProductController(IProductService productService,ILoggerManager loggerManager)
        {
            _productService = productService;
            _loggerManager = loggerManager;
        }

        /// <summary>
        /// Get the products.  
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var query = await _productService.Get();
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener los productos: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Get product by Id.
        /// </summary>
        /// <returns>
        /// Product model.
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = await _productService.GetById(id);
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error al obtener el producto: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Save product
        /// <see cref="ProductDto"/> the product model. 
        /// </summary>
        /// <param name="product"></param>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductDto product)
        {
            try
            {
                _productService.Save(product);
                // ReSharper disable once Mvc.ActionNotResolved
                return CreatedAtAction(nameof(GetById), new { idProduct = product.Id }, product);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error cuando se intentaba guardar el producto: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }

        }

        /// <summary>
        /// Delete product by Id.
        /// </summary>
        /// <returns>
        /// Product deleted.
        /// </returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var query = await _productService.DeleteById(id);
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se eliminaba el producto: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Update product.
        /// <see cref="ProductDto"/> the product model. 
        /// </summary>
        /// <param name="product"></param>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDto product)
        {
            try
            {
                var query = await _productService.Update(product);
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se modificaba el producto: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}