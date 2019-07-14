using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PrelimineryTest.Api.Controllers
{
    public class HomeController : ApiController
    {
        public HttpResponseMessage Get(int year)
        {
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }

        //public ActionResult GetAll()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}