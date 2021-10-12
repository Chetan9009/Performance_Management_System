using ApplicationLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Performance_Management_API.Contracts.Request;

namespace Performance_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalMapperAPIController : ControllerBase
    {
        [Route("AssignGoals/{empId}")]
        [HttpPost]
        public bool CreateMapGoals([FromRoute] int empId, AssignGoalRequest request)
        {

            GoalMapperUseCase createGoalMapperUseCase = new GoalMapperUseCase();
            List<CreateGoalMapper> createGoalMapper = new List<CreateGoalMapper>();
            DateTime createDate = DateTime.Now;
    
             foreach (var i in request.Goals)
            {
                createGoalMapper.Add(new CreateGoalMapper
                {

                AssignBy=request.AssignBy,
                AssignTo=empId,
                GoalIds=i,
                CreateDate=createDate

                });
                               
            }
            var appCreateGoalResponse = createGoalMapperUseCase.Execute(createGoalMapper);
            return appCreateGoalResponse;
        }
       
    }
}
