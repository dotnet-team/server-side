using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsNewsAngular.Models;
using SportsNewsAngular.Repository;

namespace SportsNewsAngular.Controllers
{
    public class TeamsController : Controller
    {
        private readonly IRepository repository;

        public TeamsController(IRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Team>>> GetAll(int? sideNavId)
        {
            var teams = await repository.FindAll<Team>();

            if (sideNavId != null)
            {
                teams = teams.FindAll(t => t.SideNavId == sideNavId);
            }

            return teams;
        }

        [HttpGet]
        public async Task<ActionResult<Team>> GetById(int id)
        {
            return await repository.FindById<Team>(id);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> Create([FromBody] Team team)
        {
            await repository.CreateAsync<Team>(team);

            return team;
        }

        [HttpPut]
        public async Task<ActionResult<Team>> Update(int id, [FromBody] Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            await repository.UpdateAsync<Team>(team);
            return team;
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            var team = await repository.FindById<Team>(id);
            if (team == null)
            {
                NotFound();
            }

            await repository.DeleteAsync<Team>(team);

        }
    }
}