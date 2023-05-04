using System.Linq;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<TModel> 
    {
        Task UpdateAsync(TModel model);
    }
}
