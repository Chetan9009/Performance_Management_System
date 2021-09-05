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


        public void Create(GoalDbEntity createGoalDbEntity)
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

       

            
        }

        public void Update(GoalDbEntity Obj)
        {
            var ids = _Context.TblGoal.Where(d => d.CreatedBy == Obj.CreatedBy).FirstOrDefault();

            ids.CreatedBy = Obj.CreatedBy;
            ids.Title = Obj.Title;
            ids.StartDate = Obj.StartDate;
            ids.EndDate = Obj.EndDate;
            ids.Score = Obj.Score;

            _Context.SaveChanges();
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
