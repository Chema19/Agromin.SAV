using Agromin.SAV.Web.ViewModel.EntryExitProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agromin.SAV.Web.Controllers
{
    public class EntryExitProductController : BaseController
    {
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> ListStockProduct()
        {
            var vm = new ListStockProductViewModel();
            await vm.Fill(CargarDatosContext());
            return View(vm);
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> ListEntryExitProduct(Int32? ProductBrandId)
        {
            var vm = new ListEntryExitProductViewModel();
            await vm.Fill(CargarDatosContext(), ProductBrandId);
            return View(vm);
        }
        //public ActionResult _AddEditEntryExitProduct()
        //{
        //    var vm = new AddEditEntryExitProductViewModel();
        //    vm.Fill(CargarDatosContext());
        //    return View(vm);
        //}
        //[HttpPost]
        //public ActionResult _AddEditEntryExitProduct(AddEditEntryExitProductViewModel model)
        //{
        //    try {
        //        return RedirectToAction("ListStockProduct", "EntryExitProduct");
        //    }
        //    catch (Exception e)
        //    {
        //        return View(model);
        //    }
        //}
    }
}