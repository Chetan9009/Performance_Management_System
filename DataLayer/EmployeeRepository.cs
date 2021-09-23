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
    }
}
