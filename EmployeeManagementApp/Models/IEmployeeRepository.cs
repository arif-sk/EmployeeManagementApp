using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployee();
        Employee GetEmployee(int id);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);
    }
}
