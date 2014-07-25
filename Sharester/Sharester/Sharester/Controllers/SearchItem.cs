using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Sharester.Controllers
{
    public class SearchItemController : ApiController
    {
        public HttpResponseMessage GetValue(string a)
        {
            return Request.CreateResponse(HttpStatusCode.OK, a, new HttpConfiguration());
        }
    }
}
