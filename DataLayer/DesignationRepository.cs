using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
   public class DesignationRepository:IDesignationRepository
    {
        PMSContext _Context = new PMSContext();
        public List<DesignationDbEntity> GetDesignation()
        {
            var allDesignation = _Context.TblDesignation.ToList();

            List<DesignationDbEntity> getAllDesignation = new List<DesignationDbEntity>();

            foreach (var i in allDesignation)
            {
                getAllDesignation.Add(new DesignationDbEntity
                {
                    Id = i.Id,
                  Designation=i.Designation
                });

            }
            return getAllDesignation;
        }
    }
}
