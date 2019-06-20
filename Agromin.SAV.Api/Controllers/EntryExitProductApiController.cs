using Agromin.SAV.Data;
using Agromin.SAV.Entities.Entities;
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
    public class EntryExitProductApiController : BaseApiController
    {
        [HttpGet]
        [Route("entryexitproducs")]
        public IHttpActionResult ListEntryExitProduct() {
            try {
                using (var ts = new TransactionScope()) {

                    response.Data = context.EntryExitProduct.Select(x => new {
                        EntryExitProductId = x.EntryExitProductId,
                        Amount = x.Amount,
                        Creation_Date = x.Creation_Date,
                        StatusType = x.StatusType,
                        UserId = x.UserId,
                        ProductBrandId = x.ProductBrandId,
                        SaleId = x.SaleId
                    }).ToList();

                    response.Error = false;
                    response.Message = "Success";
                    ts.Complete();
                }
                return Ok(response);
            } catch (Exception ex) {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("entryexitproducts")]
        public IHttpActionResult AddEntryExitProduct(EntryExitProductEntity model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {

                    EntryExitProduct entryExitProduct = new EntryExitProduct();
                    if (!model.EntryExitProductId.HasValue)
                    {
                        context.EntryExitProduct.Add(entryExitProduct);
                        entryExitProduct.StatusType = ConstantHelpers.ESTADO.ENTRADA;
                        entryExitProduct.Creation_Date = DateTime.Now;
                    }

                    entryExitProduct.Amount = model.Amount;
                    entryExitProduct.UserId = model.UserId;
                    entryExitProduct.ProductBrandId = model.ProductBrandId;
                    context.SaveChanges();

                    Decimal? entradasProducto = context.EntryExitProduct.Where(x => x.StatusType == ConstantHelpers.ESTADO.ENTRADA && x.ProductBrandId == model.ProductBrandId).Sum(x => x.Amount);
                    Decimal? salidasProducto = context.EntryExitProduct.Where(x => x.StatusType == ConstantHelpers.ESTADO.SALIDA && x.ProductBrandId == model.ProductBrandId).Sum(x => x.Amount);

                    StockProduct stockProduct = new StockProduct();
                    if (context.StockProduct.FirstOrDefault(x => x.ProductBrandId == model.ProductBrandId) != null)
                    {
                        stockProduct = context.StockProduct.FirstOrDefault(x => x.ProductBrandId == model.ProductBrandId);
                    }
                    else
                    {
                        context.StockProduct.Add(stockProduct);
                    }

                    stockProduct.Amount = (entradasProducto.HasValue ? Convert.ToDecimal(entradasProducto) : Convert.ToDecimal(0)) - (salidasProducto.HasValue ? Convert.ToDecimal(salidasProducto) : Convert.ToDecimal(0));
                    stockProduct.Status = ConstantHelpers.ESTADO.ACTIVO;
                    stockProduct.ProductBrandId = model.ProductBrandId;
                    context.SaveChanges();

                    ts.Complete();
                }
                response.Data = "User added";
                response.Error = false;
                response.Message = "Success";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpPut]
        [Route("entryexitproducts")]
        public IHttpActionResult EditEntryExitProduct(EntryExitProductEntity model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {

                    EntryExitProduct entryExitProduct = new EntryExitProduct();
                    if (model.EntryExitProductId.HasValue)
                    {
                        entryExitProduct = context.EntryExitProduct.FirstOrDefault(x => x.EntryExitProductId == model.EntryExitProductId);
                    }
                    

                    entryExitProduct.Amount = model.Amount;
                    entryExitProduct.UserId = model.UserId;
                    entryExitProduct.ProductBrandId = model.ProductBrandId;
                    context.SaveChanges();

                    Decimal? entradasProducto = context.EntryExitProduct.Where(x => x.StatusType == ConstantHelpers.ESTADO.ENTRADA && x.ProductBrandId == model.ProductBrandId).Sum(x => x.Amount);
                    Decimal? salidasProducto = context.EntryExitProduct.Where(x => x.StatusType == ConstantHelpers.ESTADO.SALIDA && x.ProductBrandId == model.ProductBrandId).Sum(x => x.Amount);

                    StockProduct stockProduct = new StockProduct();
                    if (context.StockProduct.FirstOrDefault(x => x.ProductBrandId == model.ProductBrandId) != null)
                    {
                        stockProduct = context.StockProduct.FirstOrDefault(x => x.ProductBrandId == model.ProductBrandId);
                    }
                    else
                    {
                        context.StockProduct.Add(stockProduct);
                    }

                    stockProduct.Amount = (entradasProducto.HasValue ? Convert.ToDecimal(entradasProducto) : Convert.ToDecimal(0)) - (salidasProducto.HasValue ? Convert.ToDecimal(salidasProducto) : Convert.ToDecimal(0));
                    stockProduct.Status = ConstantHelpers.ESTADO.ACTIVO;
                    stockProduct.ProductBrandId = model.ProductBrandId;
                    context.SaveChanges();

                    ts.Complete();
                }
                response.Data = "User edited";
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
