using HelperKit.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agromin.SAV.Web.Controllers
{
    public class BaseController : HelperController
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }

        public override void InvalidateContext()
        {
            throw new NotImplementedException();
        }
    }
}