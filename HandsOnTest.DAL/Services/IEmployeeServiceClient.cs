using HandsOnTest.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOnTest.DAL.Services
{
    public interface IEmployeeServiceClient
    {
       Task<List<Employee>> GetEmployees();
    }
}
