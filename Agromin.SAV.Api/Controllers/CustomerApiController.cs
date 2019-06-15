using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;
using Agromin.SAV.Data;
using Agromin.SAV.Helpers.Helpers;

namespace Agromin.SAV.Api.Controllers
{
    [RoutePrefix("SAV")]
    public class CustomerApiController : BaseApiController
    {
        [HttpGet]
        [Route("customers")]
        public IHttpActionResult ListCustomers()
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    response.Data = context.Customer.Where(x => x.Status == ConstantHelpers.ESTADO.ACTIVO).Select(x => new
                    {
                        CustomerId = x.CustomerId,
                        Names = x.Names,
                        Last_Names = x.Last_Names,
                        Sex = x.Sex,
                        Identity_Document = x.Identity_Document,
                        Email = x.Email,
                        Birthdate = x.Birthdate,
                        Creation_Date = x.Creation_Date,
                        Update_Date = x.Update_Date,
                        Status = x.Status,
                        DistrictId = x.DistrictId,
                        Phone = x.Phone
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
