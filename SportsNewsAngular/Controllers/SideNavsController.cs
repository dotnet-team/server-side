using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsNewsAngular.Models;
using SportsNewsAngular.Repository;
using SportsNewsAngular.ViewModels;

namespace SportsNewsAngular.Controllers
{
   // [Route("api/[controller]")]
    public class SideNavsController : Controller
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public SideNavsController(IRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SideNavModel>>> GetAll()
        {
            var sideNavs = await repository.FindAll<SideNav>();

            List<SideNavModel> newSideNavs = new List<SideNavModel>(); 

            foreach(SideNav s in sideNavs)
            {
                newSideNavs.Add(mapper.Map<SideNavModel>(s));
            }

            return newSideNavs;
        }

        [HttpGet]
        public async Task<ActionResult<SideNavModel>> GetById(int id)
        {
            var sideNav = await repository.FindById<SideNav>(id);
            var newsideNav = mapper.Map<SideNavModel>(sideNav);
            return newsideNav;
        }

        [HttpPost]
        public async Task<ActionResult<SideNavModel>> Create([FromBody] SideNav sideNav)
        {
            await repository.CreateAsync<SideNav>(sideNav);
            var newsideNav = mapper.Map<SideNavModel>(sideNav);

            return newsideNav;
        }

        [HttpPut]
        public async Task<ActionResult<SideNavModel>> Update(int id, [FromBody] SideNav sideNav)
        {
            if (id != sideNav.Id)
            {
                return BadRequest();
            }
            await repository.UpdateAsync<SideNav>(sideNav);

            var newsideNav = mapper.Map<SideNavModel>(sideNav);

            return newsideNav;
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