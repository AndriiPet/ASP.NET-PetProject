using DAL.Interfaces;
using DAL.Repositories;
using System.Threading.Tasks;
namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IUsersDBcontext _usersDbContext;
        private IUserRepository _usersRepository;
        private IOrderRepository _orderRepository;

        public UnitOfWork(IUsersDBcontext usersDbContext)
        {
            _usersDbContext = usersDbContext;
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_usersRepository == null)
                {
                    _usersRepository = new UserRepository(_usersDbContext);
                }
                return _usersRepository;
            }
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_usersDbContext);
                }
                return _orderRepository;
            }
        }



        public async Task<int> SaveAsync()
        {
            return await _usersDbContext.SaveChangesAsync();
        }
    }
}
