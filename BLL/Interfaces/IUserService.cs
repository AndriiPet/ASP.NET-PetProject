using BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        Task AddAsync(UserDto model);
        Task DeleteByIdAsync(int modelId);
    }
}
