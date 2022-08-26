using RayTech.DAL;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace RayTech.API.Security
{
    public class APIAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var actionRoles = Roles; //A
            var userName = HttpContext.Current.User.Identity.Name;
            UsersDal userDal = new UsersDal(); ;
            var user = userDal.GetUsersByName(userName);
            //B
            if (user != null && actionRoles.Contains(user.Role))
            {

            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

            }

        }
    }
}