using HandsOnTest.DAL.Services;
using HandsOnTest.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.BLL.Employees
{
    public class EmployeeBusiness: IEmployeeBusiness
    {
        private IEmployeeServiceClient _employeeServiceClient;

        public EmployeeBusiness(IEmployeeServiceClient employeeServiceClient)
        {
            _employeeServiceClient = employeeServiceClient;
        }
        
        public async Task<List<IEmployeeDto>> GetEmployees()
        {
            var listEmployees = await _employeeServiceClient.GetEmployees();
            var listEmployesDto = new List<IEmployeeDto>();
            var employeeFactory = new EmployeeFactory();

            foreach (var itemEmployee in listEmployees)
            {
                listEmployesDto.Add(employeeFactory.CreateEmployee(itemEmployee));
            }

            return listEmployesDto;
        }
    }
}
