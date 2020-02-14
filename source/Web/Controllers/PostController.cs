using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Post;
using DotNetCore.AspNetCore;
using DotNetCoreArchitecture.Web;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Post;

namespace Web.Controllers
{
    [ApiController]
    [RouteController]
    public class PostController : BaseController
    {
        private readonly IPostApplicationService _postApplicationService;

        public PostController(IPostApplicationService userApplicationService)
        {
            _postApplicationService = userApplicationService;
        }

        // GET: api/<controller>
        //[HttpGet]
        //public async Task<IEnumerable<PostModel>> Get()
        //{
        //    return Result(await _postApplicationService.GetPostsNearAsync());
        //}

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Result(await _postApplicationService.GetPostAsync(id));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PostModel post)
        {
            post.UserId = UserModel.Id;
            return Result(await _postApplicationService.CreatePostAsync(post));
        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _postApplicationService.DeletePostAsync(id);
        }
    }
}
