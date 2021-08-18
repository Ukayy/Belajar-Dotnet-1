using ApiEmployee.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmployee.Data
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeDbContext _employeeContext;
        public SqlEmployeeData(EmployeeDbContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            var existEmployee = _employeeContext.Employees.Find(employee.Id);
            if (existEmployee != null)
            {
                existEmployee.Name = employee.Name;
                existEmployee.Position = employee.Position;
                _employeeContext.Employees.Update(existEmployee);
                _employeeContext.SaveChanges();
            }
            return employee;
        }
        public Employee GetEmployee(Guid id)
        {
            var employee = _employeeContext.Employees.Find(id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }
    }
}
