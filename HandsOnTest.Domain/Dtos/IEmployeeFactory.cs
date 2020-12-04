using HandsOnTest.Domain.Entities;
using HandsOnTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnTest.Domain.Dtos
{
    public interface IEmployeeFactory
    {
        IEmployeeDto CreateEmployee(Employee employee);
    }
}
