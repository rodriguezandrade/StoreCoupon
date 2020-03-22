using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Profiles;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Models.Dtos;

namespace GenericProjectBase.Controllers
{
    [Route("api/v{version:apiVersion}/stores/")]
    [ApiVersion("1")]
    [ApiVersion("2")]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;
        public StoreController(IStoreService storeService, IMapper mapper )
        {
            _mapper = mapper;
            _storeService = storeService;
        }

        /// <summary>
        /// Get the stores.  
        /// </summary>
        [HttpGet]
        [Route("get")]
        public async Task<IQueryable<Store>> Get()
        {
            return await _storeService.FindAll();
        }

        /// <summary>
        /// Get store by Id.
        /// </summary>
        /// <returns>
        /// Store model.
        /// </returns>
        [HttpGet]
        [Route("get/{idStore}")]
        public async Task<Store> GetById(Guid idStore)
        {
            var query = await _storeService.FindByCondition(x => x.Id == idStore);
            return query.FirstOrDefault();
        }

        /// <summary>
        /// Save the store
        /// <see cref="StoreDto"/>The store model. 
        /// </summary>
        /// <param name="store"></param>
        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> Add([FromBody]StoreDto store)
        {
            var model = _mapper.Map<Store>(store);
            _storeService.Create(model);
            await _storeService.SaveChage();
            return CreatedAtAction(nameof(GetById), new { idStore = store.Id }, store);
        }

        /// <summary>
        /// Delete store by Id.
        /// </summary>
        /// <returns>
        /// Store deleted.
        /// </returns>
        [HttpDelete]
        [Route("delete/{idStore}")]
        public async Task<Store> DeleteByName(Guid idStore)
        {
            return await _storeService.DeleteById(idStore);
        }

        /// <summary>
        /// Update the store.
        /// <see cref="Store"/> the store model. 
        /// </summary>
        /// <param name="store"></param>
        [HttpPut]
        [Route("update")]
        public async Task<Store> Update([FromBody]Store store)
        {
            return await _storeService.Modify(store);
        }

    }
}