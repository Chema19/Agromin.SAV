using Agromin.SAV.Entities.Entities;
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
    public class LoginApiController : BaseApiController
    {
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginEntity model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    if (String.IsNullOrEmpty(model.Credential) && String.IsNullOrEmpty(model.Password))
                    {
                        response.Data = "add user and password";
                        response.Error = true;
                        response.Message = "Error";
                        return Content(HttpStatusCode.Conflict, response);
                    }
                    else if (String.IsNullOrEmpty(model.Credential) || String.IsNullOrEmpty(model.Password))
                    {
                        if (String.IsNullOrEmpty(model.Credential))
                        {
                            response.Data = "user incorrect";
                            response.Error = true;
                            response.Message = "Error";
                            return Content(HttpStatusCode.Conflict, response);
                        }
                        else
                        {
                            response.Data = "password incorrect";
                            response.Error = true;
                            response.Message = "Error";
                            return Content(HttpStatusCode.Conflict, response);
                        }
                    }
                    else if (!String.IsNullOrEmpty(model.Credential) && !String.IsNullOrEmpty(model.Password))
                    {
                        var user = context.User.FirstOrDefault(x => x.Credential == model.Credential && x.Password == model.Password);
                        if (user != null)
                        {
                            response.Data = "successfull login";
                            response.Error = false;
                            response.Message = "Success";
                            return Ok(response);
                        }
                        else
                        {
                            response.Data = "login failed";
                            response.Error = true;
                            response.Message = "Error";
                            return Content(HttpStatusCode.Conflict, response);
                        }
                    }
                    ts.Complete();
                }
                response.Data = "successfull login";
                response.Error = false;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

    }
}
