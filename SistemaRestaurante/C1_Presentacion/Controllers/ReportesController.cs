using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C1_Presentacion.Controllers
{
    public class ReportesController : Controller
    {

        [HttpGet]
        public ActionResult ReportesdeVenta()
        {
            return View();
        }


        
     

    }
}
