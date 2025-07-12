using Asp_MongoDB.Entites;

namespace Asp_MongoDB.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(Guid Id);
        Task Delete(Guid Id);
        Task Create(Employee employee);
        Task Update(Employee employee);
    }
}
