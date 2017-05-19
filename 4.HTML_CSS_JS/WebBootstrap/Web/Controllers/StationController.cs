using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class StationController : Controller
    {
        // GET: Station
        public ActionResult Index(string search = "")
        {
            var stationRepsitory = new YW.Repository.StationRepsitory();
            var stations = stationRepsitory.FindAllStations();
            if (!string.IsNullOrEmpty(search))
                stations = stations.Where(x =>
                  x.Site.Contains(search) ||
                  x.Address.Contains(search) ||
                  x.Phonenumber.Contains(search))
                  .ToList();
            ViewBag.Search = search;
            return View(stations);
        }
    }
}