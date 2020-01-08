using DotNetCore.AspNetCore;
using DotNetCore.Extensions;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Model;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreArchitecture.Web
{
    public abstract class BaseController : ControllerBase
    {
        protected UserModel UserModel => new UserModel
        {
            Id = User.Id(),
            Roles = User.RolesFlag<Roles>()
        };

        public static IActionResult Result(IResult result)
        {
            return ApiResult.Create(result);
        }

        public static IActionResult Result(object data)
        {
            return ApiResult.Create(data);
        }
    }
}
