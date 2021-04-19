using RESTAPICRUDDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPICRUDDemo.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name= "Employee One"
            },
            new Employee()
            {
                Id=Guid.NewGuid(),
                Name= "Employee Two"
            }
        };
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
            
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingemployee = GetEmployee(employee.Id);
            existingemployee.Name = employee.Name;
            return existingemployee;
        }

        public Employee GetEmployee(Guid Id)
        {
            return employees.SingleOrDefault(a => a.Id == Id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
