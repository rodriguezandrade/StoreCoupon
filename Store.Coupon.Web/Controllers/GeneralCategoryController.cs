using System; 
using System.Net;
using System.Threading.Tasks;
using Core.Exceptions;
using Core.Logger.Interface;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using Repository.Models.Dtos;
using Store.Coupon.Web;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/generalCategories/")]
    [ApiVersion("1")]
    public class GeneralCategoryController : Controller
    {
        private readonly IGeneralCategoryService _categoryService;
        private readonly ILoggerManager _loggerManager;

        public GeneralCategoryController(IGeneralCategoryService categoryService, ILoggerManager loggerManager)
        {
            _categoryService = categoryService;
            _loggerManager = loggerManager;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> Get()
        {
            try 
            {
                var query = await _categoryService.Get();
                return Ok(query);
            }
            catch(Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se obtenian las Categorias Generales: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
            
        } 
    
        [HttpPost]
        public IActionResult Add([FromBody] GeneralCategoryDto category)
        {   
            try
            {
                category.Id = Guid.NewGuid();
                _categoryService.Save(category);
                return CreatedAtAction(nameof(GetById), new { version = HttpContext.GetRequestedApiVersion().ToString(), id = category.Id }, category);
            }
            catch(Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se guardaba la Categoria General: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteByName(Guid Id)
        {
            try 
            {
                var query = await _categoryService.DeleteById(Id);
                return Ok(query);
            }
            catch(Exception e) 
            {
                _loggerManager.LogError($"Ocurrio un error mientras se eliminaba la Categoria General: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            try 
            {
                var query = await _categoryService.GetById(id);
                return Ok(query);
            }
            catch (Exception e) 
            {
                _loggerManager.LogError($"Ocurrio un error mientras se obtenia la Categoria General: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]GeneralCategoryDto category)
        {
            try
            {
                var query = await _categoryService.Update(category);
                return Ok(query);
            }
            catch (Exception e)
            {
                _loggerManager.LogError($"Ocurrio un error mientras se modificaba la Categoria General: {e}");
                throw new ApiException(AppResources.BadRequest, HttpStatusCode.BadRequest);
            }
        }
    }
}