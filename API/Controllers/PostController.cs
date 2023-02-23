using Business;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using PostEntity = Business.Entities.Post;

namespace API.Controllers.Post
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService PostService;
        public PostController(IPostService postService)
        {
            PostService = postService;
        }

        [HttpGet]
        public IQueryable<PostEntity> GetAll()
        {
            return PostService.GetAll();
        }

        [HttpPost]
        public PostEntity Create(PostEntity entity)
        {
            return PostService.Create(entity);
        }

        [HttpPost("Massive")]
        public bool CreateMassive(IEnumerable<PostEntity> entity)
        {
            return PostService.CreateMassive(entity);
        }

        [HttpPut]
        public PostEntity Update(PostEntity entity)
        {
            return PostService.Update(entity.PostId, entity, out bool changed);
        }

        [HttpDelete]
        public PostEntity Delete(PostEntity entity)
        {
            return PostService.Delete(entity);
        }


    }
}
