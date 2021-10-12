using DataLayer.Model;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
   public class EmployeeRepository: IEmployeeRepository
    {
        PMSContext _Context = new PMSContext();
        public  List<EmployeeDbEntity> GetEmployee()
        {
            var allEmployee = _Context.TblEmployee.ToList();

            List<EmployeeDbEntity> getAllEmployee = new List<EmployeeDbEntity>();
            
                foreach(var i in allEmployee)
            {
                getAllEmployee.Add(new EmployeeDbEntity
                {
                    Id = i.Id,
                    FirstName = i.FirstName
                   ,LastName=i.LastName
                });
            
            }
            return getAllEmployee;


        }

        public EmployeeDbEntity Create(EmployeeDbEntity createEmployee)
        {
            TblEmployee emp = new TblEmployee()
            {
                FirstName=createEmployee.FirstName,
                LastName=createEmployee.LastName,
                DesignationId=createEmployee.DesignationId,
                EmailId=createEmployee.EmailId,
                Password=createEmployee.Password
             };
            _Context.Add(emp);
            _Context.SaveChanges();

            EmployeeDbEntity responseEmployee = new EmployeeDbEntity();
            responseEmployee.Id = emp.Id;
            responseEmployee.FirstName = emp.FirstName;
            responseEmployee.LastName = emp.LastName;
            responseEmployee.DesignationId = emp.DesignationId;
            responseEmployee.EmailId = emp.EmailId;
            responseEmployee.Password = emp.Password;

            return responseEmployee;

        }
    }
}
