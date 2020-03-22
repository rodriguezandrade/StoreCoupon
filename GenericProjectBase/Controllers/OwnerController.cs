using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/owners/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class OwnerController : Controller
    {

        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        /// <summary>
        /// Get the owners.  
        /// </summary>
        [HttpGet]
        [Route("get")]
        public async Task<IQueryable<Owner>> Get() {
            return await _ownerService.FindAll();
        }

        /// <summary>
        /// Get owner by guid.
        ///s<see cref="Guid"/>Guid annotation. 
        /// </summary>
        /// <param name="idOwner"> id owner</param>
        /// <returns>
        /// Owner model.
        /// </returns>
        [HttpGet]
        [Route("get/{idOwner}")]
        public async Task<Owner> GetById(Guid idOwner)
        {
            var query = await _ownerService.FindByCondition(x => x.Id == idOwner);
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Save the owners
        /// <see cref="Owner"/> the owner model. 
        /// </summary>
        /// <param name="owner"></param>
        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Add([FromBody]Owner owner) {
            _ownerService.Create(owner);
            await _ownerService.SaveChage();
            return CreatedAtAction(nameof(GetById), new { idOwner = owner.Id }, owner);
        }

        /// <summary>
        /// Delete owner by Id.
        /// </summary>
        /// <returns>
        /// Owner deleted.
        /// </returns>
        [HttpDelete]
        [Route("delete/{idOwner}")]
        public async Task<Owner> DeleteByName(Guid idOwner)
        {
            return await _ownerService.DeleteById(idOwner);
        }

        /// <summary>
        /// Update the owner.
        /// <see cref="Owner"/> the owner model. 
        /// </summary>
        /// <param name="owner"></param>
        [HttpPut]
        [Route("update")]
        public async Task<Owner> Update([FromBody]Owner owner) 
        {
            return await _ownerService.Modify(owner);
        }

    }
}