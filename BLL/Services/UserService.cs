using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async  Task AddAsync(UserDto model)
        {
            User mappedUser = _mapper.Map<UserDto, User>(model);
            if(mappedUser == null)
            {
                throw new System.Exception("User wasn't found");
            }
            await _unitOfWork.UserRepository.AddAsync(mappedUser);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            User mappedUser = await _unitOfWork.UserRepository.GetByIdAsync(modelId);
            if (mappedUser == null)
            {
                throw new System.Exception("User wasn't found");
            }
            var modelOrder = await _unitOfWork.OrderRepository.GetByIdUserAsync(modelId);
            if (modelOrder == null)
            {
                await _unitOfWork.UserRepository.DeleteByIdAsync(modelId);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                throw new System.Exception("User can't be delete");
            }
        }

        public async Task UpdateAsync(UserDto model)
        {
            User mappedUser = _mapper.Map<UserDto, User>(model);
            if (mappedUser == null)
            {
                throw new System.Exception("User wasn't found");
            }
            _unitOfWork.UserRepository.Update(mappedUser);
            await _unitOfWork.SaveAsync();
        }
    }
}
