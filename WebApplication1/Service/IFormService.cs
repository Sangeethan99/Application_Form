using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IFormService
    {
        Task<List<Form>> Get(string query);
        Task<Form> GetById(string id);
        Task<Form> Add(Form employeeCreatedForm);
        Task<Form> Update(Form employeeCreatedForm);
        Task<Form> Delete(string id, string partition);
    }
}
