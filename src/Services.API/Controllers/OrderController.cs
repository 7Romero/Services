using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Order;
using Services.Common.Models.PagedRequest;
using System.Security.Claims;

namespace Services.API.Controllers
{
    [Route("api/order")]
    public class OrderController : AppBaseController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [AllowAnonymous]
        [HttpPost("paginated-search")]
        public async Task<PaginatedResult<OrderListDto>> GetPagedOrders(PagedRequest pagedRequest)
        {
            var pagedOrdersDto = await _orderService.GetPagedOrders(pagedRequest);

            return pagedOrdersDto;
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<OrderDto> GetOrder(Guid id)
        {
            var orderDto = await _orderService.GetOrder(id);

            return orderDto;
        }

        [HttpGet("/WithApplication/{id}")]
        public async Task<OrderWithApplicationDto> GetOrderWithApplication(Guid id)
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var orderDto = await _orderService.GetOrderWithApplication(id, userId);

            return orderDto;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderForUpdateDto orderForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var orderDto = await _orderService.CreateOrder(orderForUpdateDto, userId);

            return CreatedAtAction(nameof(GetOrder), new { id = orderDto.Id }, orderDto);
        }

        [HttpPut("Admin/{id}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateOrderAdmin(Guid id, OrderForUpdateDto orderForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _orderService.UpdateOrder(id, orderForUpdateDto);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, OrderForUpdateDto orderForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _orderService.UpdateOrderYourself(id, orderForUpdateDto, userId);

            return Ok();
        }

        [HttpDelete("Admin/{id}"), Authorize(Roles = "Administrator")]
        public async Task DeleteOrderAdmin(Guid id)
        {
            await _orderService.DeleteOrder(id);
        }

        [HttpDelete("{id}")]
        public async Task UpdateOrder(Guid id)
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _orderService.DeleteOrderYourself(id, userId);
        }
    }
}
