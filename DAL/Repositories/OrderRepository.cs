using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IUsersDBcontext _usersDBcontext;

        public OrderRepository(IUsersDBcontext usersDBcontext)
        {
            _usersDBcontext = usersDBcontext;
        }
        public async Task AddAsync(Order entity)
        {
            await _usersDBcontext.Set<Order>().AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            Order order = await _usersDBcontext.Set<Order>().FirstOrDefaultAsync(x => x.OrderID == id);
            _usersDBcontext.Set<Order>().Remove(order);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _usersDBcontext.Set<Order>().FirstOrDefaultAsync(x => x.OrderID == id);

        }
        public async Task<Order> GetByIdUserAsync(int id)
        {
            return await _usersDBcontext.Set<Order>().FirstOrDefaultAsync(x => x.UserID == id);

        }

        public void Update(Order entity)
        {
            _usersDBcontext.Set<Order>().Update(entity);
        }
    }
}
