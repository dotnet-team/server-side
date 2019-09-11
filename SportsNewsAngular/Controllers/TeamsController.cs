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
    public class TeamsController : Controller
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;
        public TeamsController(IRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<TeamModel>>> GetAll(int? sideNavId)
        {
            var teams = await repository.FindAll<Team>();

            if (sideNavId != null)
            {
                teams = teams.FindAll(t => t.SideNavId == sideNavId);
            }

            List<TeamModel> newTeams = new List<TeamModel>();

            foreach (Team t in teams)
            {
                newTeams.Add(mapper.Map<TeamModel>(t));
            }

            return newTeams;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamModel>>> GetShowed(int? sideNavId)
        {
            var teams = await repository.FindShowed<Team>();

            if (sideNavId != null)
            {
                teams = teams.FindAll(t => t.SideNavId == sideNavId);
            }

            List<TeamModel> newTeams = new List<TeamModel>();

            foreach (Team t in teams)
            {
                newTeams.Add(mapper.Map<TeamModel>(t));
            }

            return newTeams;
        }

        [HttpGet]
        public async Task<ActionResult<TeamModel>> GetById(int id)
        {
            var team = await repository.FindById<Team>(id);

            var newTeam = mapper.Map<TeamModel>(team);

            return newTeam;
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> Create([FromBody] Team team)
        {
            await repository.CreateAsync<Team>(team);

            var newTeam = mapper.Map<TeamModel>(team);

            return newTeam;
        }

        [HttpPut]
        public async Task<ActionResult<TeamModel>> Update(int id, [FromBody] Team team)
        {
            if (id != team.Id)
            {
                return BadRequest();
            }

            await repository.UpdateAsync<Team>(team);
            var newTeam = mapper.Map<TeamModel>(team);

            return newTeam;
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