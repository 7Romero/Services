using Services.Common.Dtos.Order;
using Services.Common.Models.PagedRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Interfaces
{
    public interface IOrderService
    {
        Task<PaginatedResult<OrderListDto>> GetPagedOrders(PagedRequest pagedRequest);

        Task<OrderDto> GetOrder(Guid id);

        Task<OrderDto> CreateOrder(OrderForUpdateDto orderForUpdateDto, Guid userId);

        Task UpdateOrder(Guid id, OrderForUpdateDto orderForUpdateDto);

        Task DeleteOrder(Guid id);

        Task UpdateOrderYourself(Guid id, OrderForUpdateDto orderForUpdateDto, Guid UserId);

        Task DeleteOrderYourself(Guid id, Guid UserId);

        Task AppointFreelancer(SelectFreelancerForOrderDto selectFreelancerForOrderDto, Guid userId);
    }
}
