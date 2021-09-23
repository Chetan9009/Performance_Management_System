using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
   public class EmployeeGetAllUseCase
    {
        public List<EmployeeGetAll> Execute()
        {
            EmployeeRepository excuteGetEmployee = new EmployeeRepository();

            var responseEmployee = excuteGetEmployee.GetEmployee();

            List<EmployeeDomainEntity> responseListEmployee = new List<EmployeeDomainEntity>();

            foreach (var i in responseEmployee)
            {
                responseListEmployee.Add(new EmployeeDomainEntity
                {
                    Id = i.Id,
                   FirstName=i.FirstName
                   ,LastName=i.LastName

                });
            }

            List<EmployeeGetAll> responseallEmployee = new List<EmployeeGetAll>();
            foreach(var i in responseListEmployee)
            {
                responseallEmployee.Add(new EmployeeGetAll
                {
                    Id = i.Id,
                    FirstName = i.FirstName
                    ,LastName=i.LastName
                });
            }

            return responseallEmployee;

        }
    }
}
