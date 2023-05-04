using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateAsync(OrderDto model)
        {
            Order mappedOrder = _mapper.Map<OrderDto, Order>(model);
            if (mappedOrder == null)
            {
                throw new System.Exception("Order wasn't found");
            }
             var modelOrder = await _unitOfWork.OrderRepository.GetByIdUserAsync(model.UserID);
            if (modelOrder != null)
            {
                if (modelOrder.OrderDate.Date == mappedOrder.OrderDate.Date)
                {
                    throw new System.Exception("Order can't be created");
                }
            }
            else
            {
                await _unitOfWork.OrderRepository.AddAsync(mappedOrder);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task UpdateAsync(OrderDto model)
        {
            Order mappedOrder = _mapper.Map<OrderDto, Order>(model);
            if (mappedOrder == null)
            {
                throw new System.Exception("Order wasn't found");
            }
            _unitOfWork.OrderRepository.Update(mappedOrder);
            await _unitOfWork.SaveAsync();

        }
    }
}
