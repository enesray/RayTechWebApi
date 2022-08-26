using RayTech.DAL;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace RayTech.API.Security
{
    public class ApiKeyHandler : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            //url ile apikey girişi örnek https://localhost:44355/api/workorderactivities/?apikey=0cd6e78d-628a-4cea-bf84-d28f38b711c5
            //var queryString = request.RequestUri.ParseQueryString();
            //var apikey = queryString["apiKey"];

            //Projenin apikeyi urlden değilde headersden giriş yapılabilmesi için
            var apikey = request.Headers.GetValues("apiKey").FirstOrDefault();

            UsersDal userDAL = new UsersDal();
            var user = userDAL.GetUserByApiKey(apikey);
            if (user != null)
            {
                var principal = new ClaimsPrincipal(new GenericIdentity(user.Name, "APIKey"));
                HttpContext.Current.User = principal;
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}