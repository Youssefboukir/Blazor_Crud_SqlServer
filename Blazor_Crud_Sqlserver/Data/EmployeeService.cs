using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_Crud_Sqlserver.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _db;
        public EmployeeService(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get all 
        public List<EmployeeInfo> GetEmployees()
        {
            var empList = _db.Employees.ToList();
            return empList;
        }
        //Create employee
        public string Create(EmployeeInfo employeeInfo)
        {
            _db.Employees.Add(employeeInfo);
            _db.SaveChanges();
            return "Save Successfully";
        }
        //Get employee By ID
        public EmployeeInfo GetEmployeeById(int id)
        {
            EmployeeInfo employee = _db.Employees.FirstOrDefault(s => s.EmployeeId == id);
            return employee;
        }

        //Update Employee Info
        public string UpdateEmlployee(EmployeeInfo employeeInfo)
        {
            _db.Employees.Update(employeeInfo);
            _db.SaveChanges();
            return "Update Successfully";
        }

        //Delete Employee
        public string DeleteEmployee(EmployeeInfo employeeInfo)
        {
            _db.Remove(employeeInfo);
            _db.SaveChanges();
            return "Delete Successfully";
        }
    }
}
