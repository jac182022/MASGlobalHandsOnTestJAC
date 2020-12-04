using HandsOnTest.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnTest.BLL.Employees
{
    public interface IEmployeeBusiness
    {
       Task<List<IEmployeeDto>> GetEmployees();
    }
}
