using ApplicationLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GoalController> _logger;

        public GoalController(ILogger<GoalController> logger)
        {
            _logger = logger;
        }

       [HttpGet]
        public GoalCreateResponse Create(GoalCreateRequest request)
        {
            GoalCreateUseCase createGoalUseCase = new GoalCreateUseCase();
            ApplicationLayer.GoalCreateRequest appCreateGoalRequst = new ApplicationLayer.GoalCreateRequest();
            appCreateGoalRequst.CreatedBy = request.CreatedBy;
            appCreateGoalRequst.Title = request.Title;
            appCreateGoalRequst.StartDate = request.StartDate;
            appCreateGoalRequst.EndDate = request.EndDate;
            appCreateGoalRequst.Score = request.Score;
            var appCreateGoalResponse= createGoalUseCase.Execute(appCreateGoalRequst);

            GoalCreateResponse createGoalResponse = new GoalCreateResponse();
            createGoalResponse.Id = appCreateGoalResponse.Id;         
            createGoalResponse.CreatedBy = appCreateGoalResponse.CreatedBy;
            createGoalResponse.Title = appCreateGoalResponse.Title;
            createGoalResponse.StartDate = appCreateGoalResponse.StartDate;
            createGoalResponse.EndDate = appCreateGoalResponse.EndDate;
            createGoalResponse.Score = appCreateGoalResponse.Score;

            return createGoalResponse;


        }
    }
}
