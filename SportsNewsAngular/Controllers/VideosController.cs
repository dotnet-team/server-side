using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsNewsAngular.Models;
using SportsNewsAngular.Repository;
using SportsNewsAngular.ViewModels;

namespace SportsNewsAngular.Controllers
{
    public class VideosController : ControllerBase
    {

        private readonly IRepository repository;
        private readonly IMapper mapper;

        public VideosController(IRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<VideoModel>>> GetAll()
        {
            var videos = await repository.FindAll<Video>();            

            List<VideoModel> newVideos = new List<VideoModel>();

            foreach (Video v in videos)
            {
                newVideos.Add(mapper.Map<VideoModel>(v));
            }

            return newVideos;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoModel>>> GetShowed()
        {
            var videos = await repository.FindShowed<Video>();

            List<VideoModel> newVideos = new List<VideoModel>();

            foreach (Video v in videos)
            {
                newVideos.Add(mapper.Map<VideoModel>(v));
            }

            return newVideos;
        }

        [HttpGet]
        public async Task<ActionResult<VideoModel>> GetById(int id)
        {
            var video = await repository.FindById<Video>(id);

            var newVideo = mapper.Map<VideoModel>(video);

            return newVideo;
        }
    }
}
