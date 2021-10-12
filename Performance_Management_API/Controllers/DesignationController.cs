using ApplicationLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Performance_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
       [Route("GetDesignation")]
        [HttpGet]
        public List<DesignationCreateResponse> GetDesignation()
        {
            DesignationUseCase getDesignation = new DesignationUseCase();

            var resopnseDesignatiomAll = getDesignation.Execute();

            List<DesignationCreateResponse> allDesignation = new List<DesignationCreateResponse>();

            foreach (var i in resopnseDesignatiomAll)
            {
                allDesignation.Add(new DesignationCreateResponse
                {
                    Id = i.Id,
                   Designation=i.Designation
                });
            }
            return allDesignation;
        }
    }
}
