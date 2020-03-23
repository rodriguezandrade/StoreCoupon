using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/products/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get the products.  
        /// </summary>
        [HttpGet]
        [Route("get")]
        public async Task<IQueryable<Product>> Get()
        {
            return await _productService.FindAll();
        }

        /// <summary>
        /// Get product by Id.
        /// </summary>
        /// <returns>
        /// Product model.
        /// </returns>
        [HttpGet]
        [Route("get/{idProduct}")]
        public async Task<Product> GetById(Guid idProduct)
        {
            var query = await _productService.FindByCondition(x => x.Id == idProduct);
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Save product
        /// <see cref="Product"/> the product model. 
        /// </summary>
        /// <param name="Product"></param>
        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Add([FromBody]Product Product)
        {
            _productService.Create(Product);
            await _productService.SaveChage();
            return CreatedAtAction(nameof(GetById), new { idProduct = Product.Id }, Product);
        }

        /// <summary>
        /// Delete product by Id.
        /// </summary>
        /// <returns>
        /// Product deleted.
        /// </returns>
        [HttpDelete]
        [Route("delete/{idProduct}")]
        public async Task<Product> DeleteByName(Guid idProduct)
        {
            return await _productService.DeleteById(idProduct);
        }

        /// <summary>
        /// Update product.
        /// <see cref="Product"/> the product model. 
        /// </summary>
        /// <param name="Product"></param>
        [HttpPut]
        [Route("update")]
        public async Task<Product> Update([FromBody]Product Product)
        {
            return await _productService.Modify(Product);
        }
    }
}