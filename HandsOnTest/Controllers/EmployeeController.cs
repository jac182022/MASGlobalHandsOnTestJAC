using HandsOnTest.BLL.Employees;
using HandsOnTest.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOnTest.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        IEmployeeBusiness _employeeBusiness;

        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet("GetEmployees/{id}")]
        public async Task<IEnumerable<IEmployeeDto>> GetEmployees([RegularExpression(@"^[0-9]{0,9}$"),DataType(DataType.Text)] int id)
        {
            var idEmployee = int.TryParse(id.ToString(), out int employeeId);

            var employeesResult = await _employeeBusiness.GetEmployees();

            if (idEmployee)
            {

                if (employeeId == 0)
                {
                    return employeesResult;
                }

                return employeesResult.Where(e => e.Id == employeeId);
            }

           return employeesResult;
        }
    }
}
