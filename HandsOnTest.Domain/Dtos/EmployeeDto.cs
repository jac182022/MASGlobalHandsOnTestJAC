using HandsOnTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnTest.Domain.Dtos
{
   public class EmployeeDto : IEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public RoleDto Role { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal AnualSalary { get; set; }
    }
}
