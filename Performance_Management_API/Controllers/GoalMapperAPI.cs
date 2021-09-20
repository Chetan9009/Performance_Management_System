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
    public class GoalMapperAPI : ControllerBase
    {
        public bool MapGoals(int empId, IEnumerable<int> goalIds)
        {

            GoalMapperUseCase createGoalMapperUseCase = new GoalMapperUseCase();
            CreateGoalMapper createGoalMapper = new CreateGoalMapper();

            createGoalMapper.EmpId = empId;
           createGoalMapper.CreateDate=new DateTime(); 

            foreach (var i in goalIds)
            {
                createGoalMapper.GoalIds = i;

                var appCreateGoalResponse = createGoalMapperUseCase.Execute(createGoalMapper);
            }
           

            


            return true;
        }
       
    }
}
