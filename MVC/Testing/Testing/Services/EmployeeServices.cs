using System;
using System.Collections.Generic;
using System.Text;
using Testing.Repositories;
using Testing.Services;
using Testing.Model;

namespace Testing.Services
{
    public sealed class EmployeeServices
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeServices(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public Employee GetEmployeeOrThrow(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id),"Id must be positive.");
            }
            var employee = _repo.GetById(id);
            if(employee is null)
            {
                throw new InvalidOperationException($"Employee with id {id} not founwd.");
            }
            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));

            }
            if (string.IsNullOrWhiteSpace(employee.Name))
            {
                throw new ArgumentException("Name is Required");
            }
            _repo.Add(employee);
        }
            






        //public Employee GetById(int id)
        //{

        //}
    }
}
