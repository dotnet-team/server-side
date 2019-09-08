using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsNewsAngular.Models;
using SportsNewsAngular.Repository;

namespace SportsNewsAngular.Controllers
{
   // [Route("api/[controller]")]
    public class SideNavsController : Controller
    {
        private readonly IRepository repository;

        public SideNavsController(IRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SideNav>>> GetAll()
        {
            var sideNavs = await repository.FindAll<SideNav>();

            return sideNavs;
        }

        [HttpGet]
        public async Task<ActionResult<SideNav>> GetById(int id)
        {
            var sideNav = await repository.FindById<SideNav>(id);

            return sideNav;
        }

        [HttpPost]
        public async Task<ActionResult<SideNav>> Create([FromBody] SideNav sideNav)
        {
            await repository.CreateAsync<SideNav>(sideNav);

            return sideNav;
        }

        [HttpPut]
        public async Task<ActionResult<SideNav>> Update(int id, [FromBody] SideNav sideNav)
        {
            if (id != sideNav.Id)
            {
                return BadRequest();
            }
            await repository.UpdateAsync<SideNav>(sideNav);

            return sideNav;
        }

        [HttpDelete]
        public async Task Delete (int id)
        {
            var sideNav = await repository.FindById<SideNav>(id);

            if (sideNav == null)
            {
                NotFound();
            }

            await repository.DeleteAsync<SideNav>(sideNav);
        }

    }
}