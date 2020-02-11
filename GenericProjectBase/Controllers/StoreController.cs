using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace GenericProjectBase.Controllers
{
    [Route("api/stores/")]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IQueryable<Store>> Get()
        {
            return await _storeService.FindAll();
        }

        [HttpGet]
        [Route("get/{idStore}")]
        public async Task<Store> GetById(Guid idStore)
        {
            var query = await _storeService.FindByCondition(x => x.Id == idStore);
            return query.FirstOrDefault();
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Add([FromBody]Store store)
        {
            _storeService.Create(store);
            await _storeService.SaveChage();
            return CreatedAtAction(nameof(GetById), new { idStore = store.Id }, store);
        }

        [HttpDelete]
        [Route("delete/{idStore}")]
        public async Task<Store> DeleteByName(Guid idStore)
        {
            return await _storeService.DeleteById(idStore);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Store> Update([FromBody]Store store)
        {
            return await _storeService.Modify(store);
        }

    }
}