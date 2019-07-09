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
    }
}
