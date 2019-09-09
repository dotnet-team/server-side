using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsNewsAngular.Models;
using SportsNewsAngular.Repository;

namespace SportsNewsAngular.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IRepository repository;

        public ArticlesController(IRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Article>>> GetAll(int? teamId, int? sideNavId)
        {
            var articles = await repository.FindAll<Article>();

            if (teamId != null)
            {
                articles = articles.FindAll(a => a.TeamId == teamId);
            }
            else if (sideNavId != null)
            {
                articles = articles.FindAll(a => a.Team.SideNavId == sideNavId);
            }

            return articles;
        }

        [HttpGet]
        public async Task<ActionResult<Article>> GetById(int id)
        {
            return await repository.FindById<Article>(id);
        }

        [HttpPost]
        public async Task<ActionResult<Article>> Create([FromBody] Article article)
        {
            await repository.CreateAsync<Article>(article);

            return article;
        }

        [HttpPut]
        public async Task<ActionResult<Article>> Update(int id, [FromBody] Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            await repository.UpdateAsync<Article>(article);
            return article;
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            var article = await repository.FindById<Article>(id);
            if (article == null)
            {
                NotFound();
            }

            await repository.DeleteAsync<Article>(article);

        }
    }
}
