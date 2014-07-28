using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using Newtonsoft.Json;
using Sharester.Models;
using Sharester.Services;

namespace Sharester.Controllers
{
    public class SearchItemController : ApiController
    {
        //public HttpResponseMessage GetValue(string a)
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, a, new HttpConfiguration());
        //}

        public HttpResponseMessage GetSearch(string query, string category)
        {
            var response = ItemService.GetItems(query, category);
            return Request.CreateResponse(HttpStatusCode.OK, response, new HttpConfiguration());
        }
    }
}
