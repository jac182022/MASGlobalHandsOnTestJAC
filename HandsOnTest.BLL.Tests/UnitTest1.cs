using HandsOnTest.BLL.Employees;
using HandsOnTest.DAL.Services;
using HandsOnTest.Domain.Dtos;
using HandsOnTest.Domain.Entities;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        Mock<IEmployeeServiceClient> employeeServiceClient { get; set; }
        IEmployeeBusiness employeeBusiness { get; set; }

        [SetUp]
        public void Setup()
        {
            var listEmployeesDto = new List<EmployeeDto>();
            employeeServiceClient = new Mock<IEmployeeServiceClient>();

            var listEmployees = new List<Employee>()
            {
                new Employee{
                    Id = 1,
                    Name = "Juan",
                    ContractTypeName = "HourlySalaryEmployee",
                    HourlySalary =60000,
                    MonthlySalary= 80000,
                    RoleId =1,
                    RoleName ="Administrator",
                    RoleDescription =""
                },
                new Employee{
                    Id = 2,
                    Name = "Sebastian",
                    ContractTypeName = "MonthlySalaryEmployee",
                    HourlySalary =60000,
                    MonthlySalary= 80000,
                    RoleId =2,
                    RoleName ="Contractor",
                    RoleDescription =""
                }
            };

            employeeServiceClient.Setup(x => x.GetEmployees()).Returns(Task.FromResult(listEmployees));

        }

        [Test]
        public void GetEmployees()
        {
            employeeBusiness = new EmployeeBusiness(employeeServiceClient.Object);

            var resultBusiness = employeeBusiness.GetEmployees();

            Assert.IsTrue(resultBusiness.Result.Count > 0 && resultBusiness.Result.All(s => s.AnualSalary >0));
        }
    }
}