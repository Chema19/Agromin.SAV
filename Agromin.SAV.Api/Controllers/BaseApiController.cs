using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Agromin.SAV.Data;

namespace Agromin.SAV.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        public AgrominSAVEntities context { set; get; }
        private CargarDatosContext cargarDatosContext { set; get; }

        public BaseApiController()
        {
            context = new AgrominSAVEntities();
        }

        public CargarDatosContext CargarDatosContext()
        {
            if (cargarDatosContext == null)
            {
                cargarDatosContext = new CargarDatosContext { context = context };
            }

            return cargarDatosContext;
        }
    }

    public class CargarDatosContext
    {
        public AgrominSAVEntities context { get; set; }
    }
}
