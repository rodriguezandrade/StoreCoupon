using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace GenericProjectBase.Controllers
{
    [Route("api/product/")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("getAll")]
        public async Task<IQueryable<Product>> Get()
        {
            return await _productService.GetAll();
        }

        [Route("save")]
        [HttpPost]
        public Product Save([FromBody] Product product)
        {
            return _productService.Save(product);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<Product> DeleteByName(Guid Id)
        {
            return await _productService.DeleteById(Id);
        }

        [Route("getById/{id}")]
        [HttpGet]
        public async Task<Product> GetById(Guid id)
        {
            return await _productService.GetById(id);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Product> Update([FromBody]Product product)
        {
            return await _productService.Update(product);
        }
    }
}