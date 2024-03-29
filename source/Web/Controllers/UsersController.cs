using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Application;
using DotNetCoreArchitecture.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Models.User;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Web
{
    [ApiController]
    [RouteController]
    public class UsersController : BaseController
    {
        private readonly IUserApplicationService _userApplicationService;

        public UsersController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> AddAsync(AddUserModel addUserModel)
        {
            var signIn = addUserModel.SignIn;
            await _userApplicationService.AddAsync(addUserModel);
            return Result(await _userApplicationService.SignInAsync(signIn));
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> GetProfile()
        {
            return Result(await _userApplicationService.GetAsync(UserModel.Id));
        }

        [HttpPost("SetAvatar")]
        public async Task<IActionResult> AddAvatarToUserAsync()
        {
            var avatar = ControllerContext.HttpContext.Request.Files()[0];

            await _userApplicationService.SetAvatarAsync(UserModel.Id, avatar);

            return Result(await _userApplicationService.GetAsync(UserModel.Id));
        }

        [AuthorizeEnum(Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Result(await _userApplicationService.DeleteAsync(id));
        }

        [HttpGet("Grid")]
        public async Task<IActionResult> GridAsync([FromQuery]PagedListParameters parameters)
        {
            return Result(await _userApplicationService.ListAsync(parameters));
        }

        [HttpPatch("{id}/Inactivate")]
        public async Task InactivateAsync(long id)
        {
            await _userApplicationService.InactivateAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync()
        {
            return Result(await _userApplicationService.ListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SelectAsync(long id)
        {
            return Result(await _userApplicationService.SelectAsync(id));
        }

        [AllowAnonymous]
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync(SignInModel signInModel)
        {
            return Result(await _userApplicationService.SignInAsync(signInModel));
        }

        [HttpPost("SignOut")]
        public async Task SignOutAsync()
        {
            await _userApplicationService.SignOutAsync(new SignOutModel(UserModel.Id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(UpdateUserModel updateUserModel)
        {
            await _userApplicationService.UpdateAsync(updateUserModel);
            return Ok();
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> UpdatePasswordAsync(UserChangePassword changePasswordModel)
        {
            var result = await _userApplicationService.UpdatePasswordAsync(changePasswordModel);

            if (result.Succeeded)
            {
                return Ok();
            }

            return Result(result);
        }
    }
}
