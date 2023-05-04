using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUsersDBcontext _usersDBcontext;

        public UserRepository(IUsersDBcontext usersDBcontext)
        {
            _usersDBcontext = usersDBcontext;
        }
        public async Task AddAsync(User entity)
        {
            await _usersDBcontext.Set<User>().AddAsync(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            User user = await _usersDBcontext.Set<User>().FirstOrDefaultAsync(x => x.UserID == id);
            _usersDBcontext.Set<User>().Remove(user);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _usersDBcontext.Set<User>().FirstOrDefaultAsync(x => x.UserID == id);
        }

        public void Update(User entity)
        {
            _usersDBcontext.Set<User>().Update(entity);
        }
    }
}
