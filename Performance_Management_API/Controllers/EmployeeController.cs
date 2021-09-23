using ApplicationLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [Route("GetEmployee")]
        [HttpGet]

        public List<EmployeeDetails> GetEmployee()
        {

            EmployeeGetAllUseCase getEmployee = new EmployeeGetAllUseCase();

            var resopnseEmployeeAll = getEmployee.Execute();

            List<EmployeeDetails> allEmployee = new List<EmployeeDetails>();

            foreach(var i in resopnseEmployeeAll)
            {
                allEmployee.Add(new EmployeeDetails
                {
                    Id = i.Id,
                    FirstName = i.FirstName,
                    LastName=i.LastName
                });
            }
            return allEmployee;
        }
   
    }
}
