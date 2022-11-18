//namespace CarDekho.Handlers
//{
//    using System.Net.Http.Headers;
//    using System.Security.Claims;
//    using System.Text;
//    using System.Text.Encodings.Web;
//    using CarDekho.Models;
//    using CarDekho.Repository;
//    using Microsoft.AspNetCore.Authentication;
//    using Microsoft.Extensions.Options;

//    public class CAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        private readonly CarDekhoDBContext car;

//        public CAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, CarDekhoDBContext car) : base(options, logger, encoder, clock )
//        {
//            this.car = car;
//        }

//        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            if (!Request.Headers.ContainsKey("Authorization"))
//            {
//                return AuthenticateResult.Fail("Authorization header was not found");
//            }

//            try
//            {
//                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
//                var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
//                string[] credntials = Encoding.UTF8.GetString(bytes).Split(":");
//                string emailAddress = credntials[0];
//                string password = credntials[1];

//                Buyer buyer = car.Buyers.Where(b => b.BuyerEmail == emailAddress && b.BuyerPassword == password).FirstOrDefault();
//                if (buyer == null)
//                    AuthenticateResult.Fail("invalid username or password");
//                else
//                {
//                    var claims = new[] { new Claim(ClaimTypes.Name, buyer.BuyerEmail) };
//                    var identity = new ClaimsIdentity(claims, Scheme.Name);
//                    var principal = new ClaimsPrincipal(identity);
//                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
//                    return AuthenticateResult.Success(ticket);
//                }
//            }
//            catch (Exception)
//            {
//                return AuthenticateResult.Fail("Error has Occured");
//            }

//            return AuthenticateResult.Fail(" ");
//        }

    /*    protected  override Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.Headers["WWW-Authenticate"] = "Basic";
            return base.HandleChallengeAsync(properties);
        }
        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string username = null;
            try
            {
                var  authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentials =  Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                username = credentials.FirstOrDefault();
                var password = credentials.LastOrDefault();

                if (!repo.CheckUser(username, password))
                {
                    throw new ArgumentException("Invalid username or Password");
                }
            }
            catch(Exception ex)
            {
                return AuthenticateResult.Fail(ex.Message);
            }
            var claims = new[] { new Claim(ClaimTypes.Name, username) };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return AuthenticateResult.Success(ticket);
        }*/


/*    }
}*/
