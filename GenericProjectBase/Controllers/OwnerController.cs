using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace GenericProjectBase.Controllers
{
    [Route("api/owners/")]
    public class OwnerController : Controller
    {

        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IQueryable<Owner>> Get() {
            return await _ownerService.FindAll();
        }

        [HttpGet]
        [Route("get/{idOwner}")]
        public async Task<Owner> GetById(Guid idOwner)
        {
            var query = await _ownerService.FindByCondition(x => x.Id == idOwner);
            return query.FirstOrDefault();
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Add([FromBody]Owner owner) {
            _ownerService.Create(owner);
            await _ownerService.SaveChage();
            return CreatedAtAction(nameof(GetById), new { idOwner = owner.Id }, owner);
        }

        [HttpDelete]
        [Route("delete/{RFC}")]
        public async Task<Owner> DeleteByName(string RFC)
        {
            return await _ownerService.DeleteByRFC(RFC);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Owner> Update([FromBody]Owner owner) 
        {
            return await _ownerService.Modify(owner);
        }

    }
}