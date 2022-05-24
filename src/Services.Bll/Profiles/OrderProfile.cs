using AutoMapper;
using Services.Common.Dtos.Order;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Bll.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<Order, OrderListDto>();
            CreateMap<Order, OrderWithApplicationDto>();
            CreateMap<OrderForUpdateDto, Order>();
        }
    }
}
