using System;
using System.Collections.Generic;
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
        public IQueryable<Owner> Get() {
            return _ownerService.FindAll();
        }

        [HttpPost]
        [Route("save")]
        public ActionResult Add([FromBody]Owner owner) {
            _ownerService.Create(owner);
            _ownerService.SaveChage();
            return Ok(); 
        }
    }
}