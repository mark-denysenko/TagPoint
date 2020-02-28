using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Geolocation;
using DotNetCoreArchitecture.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    public class GeolocationController : BaseController
    {
        private readonly IGeolocationApplicationService _geolocationApplicationService;

        public GeolocationController(IGeolocationApplicationService geolocationApplicationService)
        {
            _geolocationApplicationService = geolocationApplicationService;
        }

        // GET api/<controller>/5
        [HttpGet("Countries")]
        [AllowAnonymous]
        public async Task<IActionResult> Countries()
        {
            return Result(await _geolocationApplicationService.GetCountriesAsync());
        }
    }
}
