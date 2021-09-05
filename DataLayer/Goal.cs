using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class Goal : IGoalRepository
    {
        PMSContext _Context = new PMSContext();


        public GoalDbEntity Create(GoalDbEntity createGoalDbEntity)
        {
            TblGoal tg = new TblGoal()
            {
                CreatedBy = createGoalDbEntity.CreatedBy,
                Title = createGoalDbEntity.Title,
                StartDate = createGoalDbEntity.StartDate,
                EndDate = createGoalDbEntity.EndDate,
                Score = createGoalDbEntity.Score

            };
            _Context.Add(tg);
            _Context.SaveChanges();

            GoalDbEntity responseGoalDbEntity = new GoalDbEntity();
            responseGoalDbEntity.Id = tg.Id;
            responseGoalDbEntity.CreatedBy = tg.CreatedBy;
            responseGoalDbEntity.Title = tg.Title;
            responseGoalDbEntity.StartDate = tg.StartDate;
            responseGoalDbEntity.EndDate = tg.EndDate; 
            responseGoalDbEntity.Score = tg.Score;

            return responseGoalDbEntity;

                    
        }

        public GoalDbEntity Update(GoalDbEntity updateGoalEntity)
        {


            var setGoalEntity = _Context.TblGoal.Where(d => d.Id == updateGoalEntity.Id).FirstOrDefault();
            setGoalEntity.CreatedBy = updateGoalEntity.CreatedBy;
            setGoalEntity.Title = updateGoalEntity.Title;
            setGoalEntity.StartDate = updateGoalEntity.StartDate;
            setGoalEntity.EndDate = updateGoalEntity.EndDate;
            setGoalEntity.Score = updateGoalEntity.Score;

            _Context.SaveChanges();

            GoalDbEntity responseGoalDbEntity = new GoalDbEntity();
            responseGoalDbEntity.Id = setGoalEntity.Id;
            responseGoalDbEntity.CreatedBy = setGoalEntity.CreatedBy;
            responseGoalDbEntity.Title = setGoalEntity.Title;
            responseGoalDbEntity.StartDate = setGoalEntity.StartDate;
            responseGoalDbEntity.EndDate = setGoalEntity.EndDate;
            responseGoalDbEntity.Score = setGoalEntity.Score;

            return responseGoalDbEntity;
        }

        public void delete(int CreatedBy)
        {
            var CreatedByID = _Context.TblGoal.Where(d => d.CreatedBy == CreatedBy).FirstOrDefault();
            _Context.TblGoal.Remove(CreatedByID);
            _Context.SaveChanges();
        }

        public List <GoalDbEntity> Get()
        {

            var responseGoal = from e in _Context.TblGoal
                                select new
                               {
                                   ID = e.Id,
                                   CreatedBy = e.CreatedBy,
                                   Title = e.Title,
                                   StartDate = e.StartDate,
                                   EndDate = e.EndDate,
                                   Score = e.Score,

                               };
            //var responseGoal = _Context.TblGoal.ToList();


            return (List<GoalDbEntity>)responseGoal;
        }
    }
}
