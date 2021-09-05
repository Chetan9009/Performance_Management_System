using DataLayer;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Text;


namespace ApplicationLayer
{
    public class GoalUpdateUseCase
    {

        //public static void Main(string[] args)
        //{
        //    DateTime sdt = new DateTime(2023, 09, 01);
        //    DateTime edt = new DateTime(2023, 09, 02);

        //    GoalUpdateRequest cg = new GoalUpdateRequest()
        //    {
        //        Id = 9,
        //        CreatedBy = 3,
        //        Title = "Chetan Patil pune",
        //        StartDate = sdt,
        //        EndDate = edt,
        //        Score = "103"

        //    };
        //    //Goal g = new Goal();
        //    //g.Create(cg);
        //    GoalUpdateUseCase g = new GoalUpdateUseCase();
        //    g.Execute(cg);


        //    //g.Update(cg);
        //    // g.delete(3);
        //    //var data = g.Get();




        //}
        public GoalUpdateResponse Execute(GoalUpdateRequest updateRequest)
        {

           DomainLayer.GoalDomainEntity updateGoalDomainEntity = new DomainLayer.GoalDomainEntity();

            updateGoalDomainEntity.Id = updateRequest.Id;
            updateGoalDomainEntity.CreatedBy = updateRequest.CreatedBy;
            updateGoalDomainEntity.Title = updateRequest.Title;
            updateGoalDomainEntity.StartDate = updateRequest.StartDate;
            updateGoalDomainEntity.EndDate = updateRequest.EndDate;
            updateGoalDomainEntity.Score = updateRequest.Score;


          DataLayer.GoalDbEntity updateDbEntity = new DataLayer.GoalDbEntity();
            updateDbEntity.Id = updateGoalDomainEntity.Id;
            updateDbEntity.CreatedBy = updateGoalDomainEntity.CreatedBy;
            updateDbEntity.Title = updateGoalDomainEntity.Title;
            updateDbEntity.StartDate = updateGoalDomainEntity.StartDate;
            updateDbEntity.EndDate = updateGoalDomainEntity.EndDate;
            updateDbEntity.Score = updateGoalDomainEntity.Score;
           
            Goal excuteGoal = new Goal();
            
           var repoResponse = excuteGoal.Update(updateDbEntity);
            GoalUpdateResponse updateGoalResponse = new GoalUpdateResponse();

            updateGoalResponse.Id = repoResponse.Id;
            updateGoalResponse.CreatedBy = repoResponse.CreatedBy;
            updateGoalResponse.Title = repoResponse.Title;
            updateGoalResponse.StartDate = repoResponse.StartDate;
            updateGoalResponse.EndDate = repoResponse.EndDate;
            updateGoalResponse.Score = repoResponse.Score;
         
                                            
            return updateGoalResponse;
        }
    }
}
