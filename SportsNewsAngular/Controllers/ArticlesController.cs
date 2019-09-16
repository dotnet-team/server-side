using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsNewsAngular.Models;
using SportsNewsAngular.Repository;
using SportsNewsAngular.ViewModels;

namespace SportsNewsAngular.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IRepository repository;
        private readonly IMapper mapper;

        public ArticlesController(IRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<ActionResult<ICollection<ArticleModel>>> GetAll(int? teamId, int? sideNavId)
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

            List<ArticleModel> newArticles = new List<ArticleModel>();

            foreach (Article a in articles)
            {
                newArticles.Add(mapper.Map<ArticleModel>(a));
            }

            return newArticles;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ICollection<ArticleModel>>> GetShowed(int? teamId, int? sideNavId)
        {
            var articles = await repository.FindShowed<Article>();

            if (teamId != null)
            {
                articles = articles.FindAll(a => a.TeamId == teamId);
            }
            else if (sideNavId != null)
            {
                articles = articles.FindAll(a => a.Team.SideNavId == sideNavId);
            }

            List<ArticleModel> newArticles = new List<ArticleModel>();

            foreach (Article a in articles)
            {
                newArticles.Add(mapper.Map<ArticleModel>(a));
            }

            return newArticles;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ArticleModel>> GetById(int id)
        {
            var article = await repository.FindById<Article>(id);
            var newArticle = mapper.Map<ArticleModel>(article);
            return newArticle;
        }

        [Authorize(Roles = "Admin, Reviewer, Managers")]
        [HttpPost]
        public async Task<ActionResult<ArticleModel>> Create([FromBody] Article article)
        {
            await repository.CreateAsync<Article>(article);

            var newArticle = mapper.Map<ArticleModel>(article);
            return newArticle;
        }

        [Authorize(Roles = "Admin, Reviewer, Managers")]
        [HttpPut]
        public async Task<ActionResult<ArticleModel>> Update(int id, [FromBody] Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            await repository.UpdateAsync<Article>(article);
            var newArticle = mapper.Map<ArticleModel>(article);
            return newArticle;
        }

        [Authorize(Roles = "Admin, Reviewer, Managers")]
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
