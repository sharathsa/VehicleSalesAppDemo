using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle_Sales.Models;
using Vehicle_Sales.Service;

namespace Vehicle_Sales.Controllers
{
    public class UploadVehiclesController : Controller
    {
        readonly ICsvParserService _parser;
        readonly ICarDataService _carDataSvc;

        public UploadVehiclesController(ICsvParserService parser, ICarDataService carDataService)
        {
            _parser = parser;
            _carDataSvc = carDataService;
        }
        // GET: UploadVehicles
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> UploadFile(HttpPostedFileBase uploadFile)
        {
            var salesData = new List<VehicleModel>();
            if (uploadFile != null)
            {

                salesData = await _parser.ProcessCsv(uploadFile.InputStream, _carDataSvc.TransformCarData);
            }
            TempData["SalesData"] = salesData;
            return RedirectToAction("DisplayResults");
        }

        public ActionResult DisplayResults()
        {
            var salesData = new List<VehicleModel>();
            if (TempData["SalesData"] != null)
            {
                salesData = (List<VehicleModel>)TempData["SalesData"];

                var carWithMaxSales = salesData.GroupBy(p => p.Vehicle).OrderByDescending(p => p.Count())?.FirstOrDefault()?.Key;
                ViewBag.SuperSalesMessage = $"Car With Max Sales: {carWithMaxSales}";

            }
            else
            {
                return RedirectToAction("UploadFile");
            }

            return View(salesData);
        }
    }
}