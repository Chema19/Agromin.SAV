using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web.Http;

namespace Agromin.SAV.Api.Controllers
{
    public class EntryExitProductApiController : BaseApiController
    {
        public IHttpActionResult ListEntryExitProduct() {
            try {
                using (var ts = new TransactionScope()) {

                    response.Data = context.EntryExitProduct.Select(x => new { }).ToList();

                    response.Error = false;
                    response.Message = "Success";
                    ts.Complete();
                }
                return Ok(response);
            } catch (Exception ex) {
                return Unauthorized();
            }
        }
    }
}
