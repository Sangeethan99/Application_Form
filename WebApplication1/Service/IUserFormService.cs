using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IUserFormService
    {
        Task<List<UserForm>> Get(string query);
        Task<UserForm> GetById(string id);
        Task<UserForm> Add(UserForm userForm);
        Task<UserForm> Update(UserForm userForm);
        Task<UserForm> Delete(string id, string partition);
    }
}
