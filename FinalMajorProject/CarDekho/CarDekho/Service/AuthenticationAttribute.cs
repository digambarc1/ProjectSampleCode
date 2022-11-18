//using System.Net;
//using System.Security.Principal;
//using System.Text;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace CarDekho.Service
//{
//    public class AuthenticationAttribute:AuthorizationFilterAttribute
//    {

//        public override void OnAuthorization(HttpActionContext actionContext)
//        {
//            if (actionContext.Request.Headers.Authorization == null)
//            {
//                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
//            }
//            else
//            {
//                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
//               string decodedAuthentication = Encoding.UTF8.GetString (Convert.FromBase64String(authenticationToken));
//               string[] usernamePasswordArray =decodedAuthentication.Split(':');
//                string email = usernamePasswordArray[0];
//                string password = usernamePasswordArray[1];

//                if(BuyerSecurity.Login(email,password))
//                {
//                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(email),null);
//                }
//                else
//                {
//                    actionContext.Response = actionContext.Request
//                        .CreateResponse(HttpStatusCode.Unauthorized);

//                }


//            }
//        }    
//    }
//}
