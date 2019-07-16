using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public SQLEmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Employee Add(Employee employee)
        {
            _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
           Employee employee = _appDbContext.Employees.Find(id);
            if (employee != null)
            {
                _appDbContext.Employees.Remove(employee);
                _appDbContext.SaveChanges();
            }
            return employee;
        }

        public List<Employee> GetEmployee()
        {
            return _appDbContext.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
             return _appDbContext.Employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _appDbContext.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
            return employeeChanges;
        }
    }
}
