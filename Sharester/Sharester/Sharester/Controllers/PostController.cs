using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Sharester.Models;
using Sharester.Services;

namespace Sharester.Controllers
{
    public class PostController : ApiController
    {
        /// <summary>
        /// Gets the Post with postId provided.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(Guid postId)
        {
            var response = PostService.GetPost(postId);
            return Request.CreateResponse(HttpStatusCode.OK, response, new HttpConfiguration());
        }

        /// <summary>
        /// Updates the post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public HttpResponseMessage Post(Guid postId)
        {
            var response = PostService.UpdatePost(postId, Request.Content.ToString(), Guid.NewGuid());
            return Request.CreateResponse(HttpStatusCode.Accepted, response, new HttpConfiguration());
        }

        /// <summary>
        /// Creates the new post
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage Put(Guid userId)
        {
            var response = PostService.CreatePost(Request.Content.ReadAsStringAsync().Result, userId);
            return Request.CreateResponse(HttpStatusCode.Accepted, response, new HttpConfiguration());
        }
    }
}