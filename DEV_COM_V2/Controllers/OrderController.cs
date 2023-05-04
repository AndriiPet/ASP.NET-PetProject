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
    public class OrderController : ControllerBase
    {
        

        private readonly IOrderService _orderService;
         
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("{CreateMany}")]
        public async Task<IActionResult> Create([FromBody] List<OrderDto> listDto)
        {
            foreach (OrderDto userDto in listDto)
            {
                try
                {
                    await _orderService.CreateAsync(userDto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            return Ok("Add successful");
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        {
            try
            {
                await _orderService.CreateAsync(orderDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Create was successful");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderDto orderDto)
        {
            try
            {
                await _orderService.UpdateAsync(orderDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Update was successful");
        }
    }
}
