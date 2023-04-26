using Microsoft.AspNetCore.Mvc;
using PI_SEC.Entities;
using PI_SEC.Interfaces.Services;

namespace PI_SEC.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        [ApiExplorerSettings(GroupName = "user")]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser(User request)
        {
            try
            {
                var response = await _userServices.CreateUser(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ApiExplorerSettings(GroupName = "user")]
        [Route("Get/{userId}")]
        public async Task<IActionResult> GetUserById(long userId)
        {
            try
            {
                var response = await _userServices.GetUser(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ApiExplorerSettings(GroupName = "user")]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User request)
        {
            try
            {
                var response = await _userServices.UpdateUser(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [ApiExplorerSettings(GroupName = "user")]
        [Route("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(long userId)
        {
            try
            {
                var response = await _userServices.DeleteUser(userId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
