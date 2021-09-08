using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;


namespace ApplicationLayer
{
    public class GoalCreateUseCase
    {

        //public static void Main(string[] args)
        //{
        //    DateTime sdt = new DateTime(2022, 09, 01);
        //    DateTime edt = new DateTime(2022, 09, 02);

        //    GoalCreateRequest cg = new GoalCreateRequest()
        //    {

        //        CreatedBy = 3,
        //        Title = "Chetan Patil pune",
        //        StartDate = sdt,
        //        EndDate = edt,
        //        Score = "103"

        //    };
        //    //Goal g = new Goal();
        //    //g.Create(cg);
        //    GoalCreateUseCase g = new GoalCreateUseCase();
        //    g.Execute(cg);


        //    //g.Update(cg);
        //    // g.delete(3);
        //    //var data = g.Get();




        //}
        public GoalCreateResponse Execute(GoalCreateRequest request)
        {

           DomainLayer.GoalDomainEntity createGoalDomainEntity = new DomainLayer.GoalDomainEntity();
            createGoalDomainEntity.CreatedBy = request.CreatedBy;
            createGoalDomainEntity.Title = request.Title;
            createGoalDomainEntity.StartDate = request.StartDate;
            createGoalDomainEntity.EndDate = request.EndDate;
            createGoalDomainEntity.Score = request.Score;


          DataLayer.GoalDbEntity createDbEntity = new DataLayer.GoalDbEntity();
            createDbEntity.Id = createGoalDomainEntity.Id;
            createDbEntity.CreatedBy = createGoalDomainEntity.CreatedBy;
            createDbEntity.Title = createGoalDomainEntity.Title;
            createDbEntity.StartDate = createGoalDomainEntity.StartDate;
            createDbEntity.EndDate = createGoalDomainEntity.EndDate;
            createDbEntity.Score = createGoalDomainEntity.Score;
           
            GoalRepository excuteGoal = new GoalRepository();
            
           var repoResponse = excuteGoal.Create(createDbEntity);
            GoalCreateResponse createGoalResponse = new GoalCreateResponse();
        
                createGoalResponse.Id = repoResponse.Id;
                createGoalResponse.CreatedBy = repoResponse.CreatedBy;
                createGoalResponse.Title = repoResponse.Title;
                createGoalResponse.StartDate = repoResponse.StartDate;
                createGoalResponse.EndDate = repoResponse.EndDate;
                createGoalResponse.Score = repoResponse.Score;
         
                                            
            return createGoalResponse;
        }
    }
}
