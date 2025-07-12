using Asp_MongoDB.Entites;
using Asp_MongoDB.Models;
using MongoDB.Driver;

namespace Asp_MongoDB.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;
        public EmployeeService(MongoSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _employee = database.GetCollection<Employee>("Employees");
        }
        public async Task Create(Employee employee)
        {
             await _employee.InsertOneAsync(employee);
        }

        public async Task Delete(Guid Id)
        {
           await _employee.DeleteOneAsync(x => x.Id == Id);
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _employee.Find(x=> true).ToListAsync();
        }

        public async Task<Employee> GetById(Guid Id)
        {
            return await  _employee.Find(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task Update(Employee employee)
        {
            await _employee.ReplaceOneAsync(x => x.Id == employee.Id, employee);
        }
    }
}
