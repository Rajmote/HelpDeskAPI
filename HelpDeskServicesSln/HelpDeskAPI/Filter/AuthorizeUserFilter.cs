using HelpDeskDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace HelpDeskAPI.Filter
{
    public class AuthorizeUserFilter : AuthorizationFilterAttribute
    {       
        bool Active = true;

        public AuthorizeUserFilter()
        { }

        /// <summary>
        /// Overriden constructor to allow explicit disabling of this
        /// filter's behavior. Pass false to disable (same as no filter
        /// but declarative)
        /// </summary>
        /// <param name="active"></param>
        public AuthorizeUserFilter(bool active)
        {
            Active = active;
        }


        /// <summary>
        /// Override to Web API filter method to handle Basic Auth check
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (Active)
            {
                var _accountrepository = new AccountRepository();
                var securityToken = HttpContext.Current.Request.Headers["securityToken"].ToString();
                var userId = Convert.ToInt32(HttpContext.Current.Request.Headers["userId"]);
                var IsAuthorized = _accountrepository.IsAuthenticated(userId, securityToken);
                
                if (!IsAuthorized)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                    return;
                }
                base.OnAuthorization(actionContext);
            }
        }       
    }
}