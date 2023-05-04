using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEV_COM_V2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("{AddMany}")]
        public async Task<IActionResult> AddMany([FromBody] List<UserDto> listDto)
        {
            foreach (UserDto userDto in listDto)
            {
                try
                {
                    await _userService.AddAsync(userDto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return Ok("Add successful");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDto userDto)
        {
            try
            {
                await _userService.AddAsync(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Add successful");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDto userDto)
        {
            try
            {
                await _userService.UpdateAsync(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Update successful");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            try
            {
                await _userService.DeleteByIdAsync(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Delete successful");
        }
    }
}
