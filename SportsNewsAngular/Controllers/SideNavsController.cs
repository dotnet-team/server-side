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
        public async Task<ActionResult<IEnumerable<SideNaw>>> GetAll()
        {
            var sideNavs = await repository.FindAll<SideNaw>();

            return sideNavs;
        }

        [HttpGet]
        public async Task<ActionResult<SideNaw>> GetById(int id)
        {
            var sideNav = await repository.FindById<SideNaw>(id);

            return sideNav;
        }

        [HttpPost]
        public async Task<ActionResult<SideNaw>> Create([FromBody] SideNaw sideNaw)
        {
            await repository.CreateAsync<SideNaw>(sideNaw);

            return sideNaw;
        }

        [HttpPost]
        public async Task<ActionResult<SideNaw>> Update(int id, [FromBody] SideNaw sideNaw)
        {
            await repository.UpdateAsync<SideNaw>(sideNaw);

            return sideNaw;
        }

        [HttpDelete]
        public async Task Delete (int id)
        {
            var sideNav = await repository.FindById<SideNaw>(id);

            if (sideNav == null)
            {
                NotFound();
            }

            await repository.DeleteAsync<SideNaw>(sideNav);
        }

    }
}