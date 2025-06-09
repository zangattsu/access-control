using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Api.Features.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet(Name = "GetUsers")]
        [Authorize]
        public Task<int> Get()
        {
            return StatusCodes.Status200OK;
        }
    }
}
