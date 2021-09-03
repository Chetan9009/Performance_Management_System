using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    class Goal : IGoalRepository
    {
        PMSContext _Context = new PMSContext();


        public void Create(GoalDbEntity Obj)
        {
            TblGoal tg = new TblGoal()
            {
                CreatedBy = Obj.CreatedBy,
                Title = Obj.Title,
                StartDate = Obj.StartDate,
                EndDate = Obj.EndDate,
                Score = Obj.Score

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

            var innerJoin = from e in _Context.TblGoal
                            join d in _Context.TblEmployee on e.CreatedBy equals d.Id
                            select new
                            {
                                CreatedBy=d.FirstName + " " +d.LastName,
                                Title=e.Title,
                                StartDate=e.StartDate,
                                EndDate=e.EndDate,
                                Score =e.Score
                            };
            //var obj = _Context.TblGoal.ToList();
            return (List<GoalDbEntity>)  innerJoin;
        }
    }
}
