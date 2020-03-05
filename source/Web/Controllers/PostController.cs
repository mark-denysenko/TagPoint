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

        [HttpGet("My")]
        public async Task<IActionResult> Get()
        {
            return Result(await _postApplicationService.GetUserPosts(UserModel.Id));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Result(await _postApplicationService.GetPostAsync(id));
        }

        [HttpGet("{latitude}/{longitude}/{radius}")]
        public async Task<IActionResult> Get(double latitude, double longitude, double radius)
        {
            return Result(await _postApplicationService.GetMarkerWithPostsNearAsync(
                new Domain.ValueObjects.Coordinate
                {
                    Latitude = latitude,
                    Longitude = longitude
                },
                radius));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PostModel post)
        {
            post.UserId = UserModel.Id;
            await _postApplicationService.CreatePostAsync(post);
            return Result(await _postApplicationService.GetMarkerWithPostsNearAsync(
                new Domain.ValueObjects.Coordinate
                {
                    Latitude = post.Marker.Latitude,
                    Longitude = post.Marker.Longitude
                },
                0.0001));
        }

        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _postApplicationService.DeletePostAsync(id);
        }
    }
}
