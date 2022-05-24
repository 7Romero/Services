using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Services.Bll.Interfaces;
using Services.Common.Dtos.Order;
using Services.Common.Exceptions;
using Services.Common.Models.PagedRequest;
using Services.Dal.Interfaces;
using Services.Domain;
using Services.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IMapper _mapper;
        public OrderService(IGenericRepository genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<OrderDto> CreateOrder(OrderForUpdateDto orderForUpdateDto, Guid userId)
        {
            var category = _genericRepository.GetById<Category>(orderForUpdateDto.CategoryId);
            if (category == null) 
            {
                throw new ValidationException("Category not found");
            }

            var user = _genericRepository.GetById<User>(userId);
            if (user == null)
            {
                throw new ValidationException("User not found");
            }

            var order = _mapper.Map<Order>(orderForUpdateDto);
            order.UserId = userId;

            _genericRepository.Add(order);
            await _genericRepository.SaveChangesAsync();

            var orderDto = _mapper.Map<OrderDto>(order);

            return orderDto;
        }

        public async Task DeleteOrder(Guid id)
        {
            var order = await _genericRepository.GetById<Order>(id);
            CheckExist(order);

            await _genericRepository.Delete<Order>(id);

            await _genericRepository.SaveChangesAsync();
        }

        public async Task<OrderDto> GetOrder(Guid id)
        {
            var order = await _genericRepository.GetByIdWithInclude<Order>(id, order => order.Category, order => order.User);
            CheckExist(order);

            var orderDto = _mapper.Map<OrderDto>(order);

            return orderDto;
        }

        public async Task<OrderWithApplicationDto> GetOrderWithApplication(Guid id, Guid userId)
        {
            var order = await _genericRepository.GetByIdWithInclude<Order>(id, order => order.Applications);
            CheckExist(order);

            if (order.UserId != userId)
            {
                throw new ValidationException("Access error");
            }

            var orderDto = _mapper.Map<OrderWithApplicationDto>(order);

            return orderDto;
        }

        public async Task<PaginatedResult<OrderListDto>> GetPagedOrders(PagedRequest pagedRequest)
        {
            var pagedOrdersDto = await _genericRepository.GetPagedData<Order, OrderListDto>(pagedRequest);

            return pagedOrdersDto;
        }

        public async Task UpdateOrder(Guid id, OrderForUpdateDto orderForUpdateDto)
        {
            var order = await _genericRepository.GetById<Order>(id);
            CheckExist(order);

            _mapper.Map(orderForUpdateDto, order);

            await _genericRepository.SaveChangesAsync();
        }

        public async Task DeleteOrderYourself(Guid id, Guid userId)
        {
            var order = await _genericRepository.GetById<Order>(id);
            CheckExist(order);

            if (order.UserId != userId)
            {
                throw new ValidationException("Access error");
            }

            await _genericRepository.Delete<Order>(id);
            await _genericRepository.SaveChangesAsync();
        }

        public async Task UpdateOrderYourself(Guid id, OrderForUpdateDto orderForUpdateDto, Guid userId)
        {
            var order = await _genericRepository.GetById<Order>(id);
            CheckExist(order);

            if (order.UserId != userId)
            {
                throw new ValidationException("Access error");
            }

            _mapper.Map(orderForUpdateDto, order);

            await _genericRepository.SaveChangesAsync();
        }
        private static void CheckExist(Order? order)
        {
            if (order == null)
            {
                throw new ValidationException("Order not found");
            }
        }
    }
}
