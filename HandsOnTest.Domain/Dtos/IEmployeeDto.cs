using HandsOnTest.Domain.Enums;

namespace HandsOnTest.Domain.Dtos
{
    public interface IEmployeeDto
    {
        int Id { get; set; }
        string Name { get; set; }
        string ContractTypeName { get; set; }
        RoleDto Role { get; set; }
        decimal HourlySalary { get; set; }
        decimal MonthlySalary { get; set; }
        decimal AnualSalary { get; set; }
    }
}
