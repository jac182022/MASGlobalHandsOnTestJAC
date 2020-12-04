using HandsOnTest.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HandsOnTest.DAL.Services
{
    public class EmployeesServiceClient: IEmployeeServiceClient
    {
        public EmployeesServiceClient()
        {
            GetEmployees();
        }

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employeeList = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }
            return employeeList;
        }
    }
}
