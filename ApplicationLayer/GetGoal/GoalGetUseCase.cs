using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer
{
   public class GoalGetUseCase
    {
        public List<GoalGetResponse> Execute( )
        {
            GoalRepository excuteGoal = new GoalRepository();

           var repoResponse = excuteGoal.Get();

            List<GoalGetResponse> responseListGoals = new List<GoalGetResponse>();
           
            foreach (var i in repoResponse)
            {
                responseListGoals.Add(new GoalGetResponse
                {
                    Id = i.Id,
                    CreatedBy = i.CreatedBy,
                    Title = i.Title,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    Score = i.Score

                });
            }

            return responseListGoals;

        }

        public List<GoalGetResponse> Execute(int id)
        {
            GoalRepository excuteGoal = new GoalRepository();

            var repoResponse = excuteGoal.Get(id);

            List<GoalGetResponse> responseListGoals = new List<GoalGetResponse>();

            foreach (var i in repoResponse)
            {
                responseListGoals.Add(new GoalGetResponse
                {
                    Id = i.Id,
                    CreatedBy = i.CreatedBy,
                    Title = i.Title,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    Score = i.Score

                });
            }

            return responseListGoals;

        }
    }
}
