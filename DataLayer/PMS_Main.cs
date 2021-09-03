using System;
using System.Collections.Generic;
using System.Text;


namespace DataLayer
{
    class PMS_Main
    {
        public static void Main(string[] args)
        {
            DateTime sdt = new DateTime(2021, 09, 01);
            DateTime edt = new DateTime(2021, 09, 02);

            GoalDbEntity cg = new GoalDbEntity()
            {
            
                CreatedBy = 3,
                Title = "Chetan Patil pune",
                StartDate = sdt,
                EndDate = edt,
                Score = "103"

            };
            Goal g = new Goal();
            g.Create(cg);
            //g.Update(cg);
            // g.delete(3);
            var data=g.Get();




        }
    }
}
