using System;
using System.Collections.Generic;
using System.Text;
using HandsOnTest.Domain.Entities;
using HandsOnTest.Domain.Enums;

namespace HandsOnTest.Domain.Dtos
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public EmployeeFactory()
        {
        }

        public IEmployeeDto CreateEmployee(Employee employee)
        {
            var contractType = Enum.Parse(typeof(EContractType), employee.ContractTypeName);

            var employeeDto = new EmployeeDto
            {
                Name = employee.Name,
                Id = employee.Id,
                ContractTypeName = employee.ContractTypeName,
                HourlySalary = employee.HourlySalary,
                MonthlySalary = employee.MonthlySalary,
                Role = new RoleDto { RoleId = employee.RoleId, RoleName = employee.RoleName, RoleDescription = employee.RoleDescription },
            };

            switch (contractType)
            {
                case EContractType.HourlySalaryEmployee:
                    employeeDto.AnualSalary = 120 * employee.HourlySalary * 12;
                    break;
                case EContractType.MonthlySalaryEmployee:
                    employeeDto.AnualSalary = employee.MonthlySalary * 12;
                    break;
            }

            return employeeDto;
        }
    }
}
