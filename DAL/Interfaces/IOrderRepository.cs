using DAL.Entities;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByIdUserAsync(int id);
    }
}
