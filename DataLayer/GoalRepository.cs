using DataLayer.Model;
using DataLayer.Models;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataLayer
{
    public class GoalRepository : IGoalRepository
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

        public void delete(int id)
        {
            var CreatedByID = _Context.TblGoal.Where(d => d.Id == id).FirstOrDefault();
            _Context.TblGoal.Remove(CreatedByID);
            _Context.SaveChanges();

           
        }

        public List <GoalDbEntity> Get()
        {

            //var responseGoal = from e in _Context.TblGoal
            //                    select new
            //                   {
            //                       ID = e.Id,
            //                       CreatedBy = e.CreatedBy,
            //                       Title = e.Title,
            //                       StartDate = e.StartDate,
            //                       EndDate = e.EndDate,
            //                       Score = e.Score,

            //                   };
            var responseGoal = _Context.TblGoal.ToList();

            List<GoalDbEntity> responseListGoals = new List<GoalDbEntity>();

            foreach (var i in responseGoal)
            {
                responseListGoals.Add(new GoalDbEntity
                {
                    Id=i.Id,
                    CreatedBy=i.CreatedBy,
                    Title=i.Title,
                    StartDate=i.StartDate,
                    EndDate=i.EndDate,
                    Score=i.Score
                    
                });
            }

            //List<GoalDbEntity> responseGetAllGoals =new List<GoalDbEntity> ((IEnumerable<GoalDbEntity>)responseGoal);

            return responseListGoals;
        }


        public List<EmployeeGoalDbEntity> GetEmpGoal()
        {
                   
            List<EmployeeGoalDbEntity> responseEmployeegoals = new List<EmployeeGoalDbEntity>();
            var responseGoal = from g in _Context.TblGoal
                               join e in _Context.TblEmployee on g.CreatedBy equals e.Id
                               select new
                               {
                                   ID = g.Id,
                                   CreatedBy = g.CreatedBy,
                                   EmpFirstName = e.FirstName,
                                   EmpLastName = e.LastName,
                                   Title = g.Title,
                                   StartDate = g.StartDate,
                                   EndDate = g.EndDate,
                                   Score = g.Score,

                               };

            foreach (var i in responseGoal)
            {

                responseEmployeegoals.Add(new EmployeeGoalDbEntity
                {
                    Id = i.ID,
                    CreatedBy = i.CreatedBy,
                    FirstName=i.EmpFirstName,
                    LastName=i.EmpLastName,
                    Title = i.Title,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    Score = i.Score
                });

            }
           
            return responseEmployeegoals;

        }
        public List<GoalDbEntity> Get(int id)
        {

            var responseGoal = from e in _Context.TblGoal where e.Id ==id
                               select new
                               {
                                  Id=e.Id,
                                   CreatedBy = e.CreatedBy,
                                   Title = e.Title,
                                   StartDate = e.StartDate,
                                   EndDate = e.EndDate,
                                   Score = e.Score,

                               };
           // var responseGoal = _Context.TblGoal.ToList();

            List<GoalDbEntity> responseListGoal = new List<GoalDbEntity>();

            foreach (var i in responseGoal)
            {
                responseListGoal.Add(new GoalDbEntity
                {
                    Id=i.Id,
                    CreatedBy = i.CreatedBy,
                    Title = i.Title,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    Score = i.Score

                });
            }

            //List<GoalDbEntity> responseGetAllGoals =new List<GoalDbEntity> ((IEnumerable<GoalDbEntity>)responseGoal);

            return responseListGoal;
        }

        public bool CreateGoalMapper(List<GoalMapperDbEntity> createGoalMapper)
        {
            List<TblEmployeeGoalMapping> createGoalMapping = new List<TblEmployeeGoalMapping>();
            foreach(var i in createGoalMapper)
            {
                createGoalMapping.Add(new TblEmployeeGoalMapping
                {
                    AssignBy = i.AssignBy,
                    AssignTo=i.AssignTo,
                    Goalid = i.Goalid,
                    CreateDate = i.CreateDate
                });
              

            };
            _Context.BulkInsert(createGoalMapping);
            _Context.SaveChanges();
            return true;

        }
    }
}
