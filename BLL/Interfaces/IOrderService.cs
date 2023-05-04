using BLL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService : IService<OrderDto>
    {
        Task CreateAsync(OrderDto model);
    }
}
