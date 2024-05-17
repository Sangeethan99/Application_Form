using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface ITodoService
    {
        Task<List<User>> Get(string query);
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task<User> Delete(string id,string partition);
    }
}
