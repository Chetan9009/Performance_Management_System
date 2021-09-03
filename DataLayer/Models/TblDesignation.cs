using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class TblDesignation
    {
        public TblDesignation()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int Id { get; set; }
        public string Designation { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
