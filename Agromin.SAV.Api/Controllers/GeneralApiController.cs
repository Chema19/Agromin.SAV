using Agromin.SAV.Helpers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;

namespace Agromin.SAV.Api.Controllers
{
    [RoutePrefix("SAV")]
    public class GeneralApiController : BaseApiController
    {
        [HttpGet]
        [Route("districts/{provinceid}")]
        public IHttpActionResult ListDistricts(Int32? ProvinceId)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    response.Data = context.District.Where(x => x.ProvinceId == ProvinceId).Select(x => new
                    {
                        DistrictId = x.DistrictId,
                        Name = x.Name
                    }).ToList();

                    response.Error = false;
                    response.Message = "Success";
                    ts.Complete();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("provinces/{departmentid}")]
        public IHttpActionResult ListProvinces(Int32? DepartmentId)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    response.Data = context.Province.Where(x => x.DepartmentId == DepartmentId).Select(x => new
                    {
                       ProvinceId = x.ProvinceId,
                       Name = x.Name
                    }).ToList();

                    response.Error = false;
                    response.Message = "Success";
                    ts.Complete();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("departments")]
        public IHttpActionResult ListDepartmens()
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    response.Data = context.Department.Select(x => new
                    {
                        DepartmentId = x.DepartmentId,
                        Name = x.Name
                    }).ToList();

                    response.Error = false;
                    response.Message = "Success";
                    ts.Complete();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }
}
