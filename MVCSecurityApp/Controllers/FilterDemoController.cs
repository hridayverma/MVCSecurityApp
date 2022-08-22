using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSecurityApp.Controllers
{
    [AllowAnonymous]
    public class FilterDemoController : Controller
    {
        // GET: FilterDemo
        public ActionResult Index()
        {
            /* try
             {
                 throw new Exception();
             }
             catch (Exception)
             {

                 ViewBag.Error = "Some error occured!!!"; 
             }

             */
            throw new Exception();
            return View();
        }

        //to check caching
        [OutputCache(Duration =40,Location =System.Web.UI.OutputCacheLocation.Any)]
        public ActionResult Index2()
        {

            ViewBag.CurrentTime = "Page Cached :" + DateTime.Now;
            return View();
        }






    }
}