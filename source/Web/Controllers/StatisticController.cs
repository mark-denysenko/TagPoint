using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Post;
using DotNetCore.AspNetCore;
using DotNetCoreArchitecture.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Post;

namespace Web.Controllers
{
    [ApiController]
    [RouteController]
    public class StatisticController : BaseController
    {
        private readonly ITagSelectionRepository tagSelectionRepository;

        public StatisticController(ITagSelectionRepository tagSelectionRepository)
        {
            this.tagSelectionRepository = tagSelectionRepository;
        }

        [HttpPost("userTypeSeletions")]
        public async Task<IActionResult> AddTagStatistic([FromBody] TagModel tag)
        {
            await tagSelectionRepository.CreateTagSelectionForUser(tag.Tag, UserModel.Id);

            return Ok(await tagSelectionRepository.GetUserTagSelection(UserModel.Id));
        }

        [HttpGet("userPreferredTypes")]
        public async Task<IActionResult> GetUserTypes()
        {
            return Ok(await tagSelectionRepository.GetUserTagSelection(UserModel.Id));
        }
    }
}
