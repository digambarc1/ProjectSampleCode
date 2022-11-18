namespace CarDekho.Controllers
{
    using CarDekho.Models;
    using CarDekho.Repository;
    using CarDekho.Service;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Net.Http.Headers;
    using System.Text;

    //[Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerRepo repo;
        private readonly CarDekhoDBContext context;

        public BuyerController(IBuyerRepo repo, CarDekhoDBContext context)
        {
            this.repo = repo;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Buyer>> Create([FromBody] Buyer u)
        {

            try
            {
                if (u == null)
                {
                    return this.BadRequest();
                }

                var createBuyer = this.Ok(await this.repo.Create(u));
                return createBuyer;
            }
            catch (Exception)
            {
                return this.StatusCode(
                  StatusCodes.Status500InternalServerError,
                  "Error Receving Data From The Database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<Buyer>> GetById(long id)
        {
            var res = await this.repo.GetById(id);
            try
            {
                if (res == null)
                {
                    return NotFound();
                }

                return res;
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }



        }

        [HttpDelete]

        public async Task<ActionResult> DeleteById(long id)
        {
           try{
                if (id == null)
                {
                    return NotFound($"Buyer with ID ={id} not found");
                }
                this.repo.DeleteById(id);

                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Buyer>> UpdateById(int id, [FromBody] Buyer buyer)
        {
            try
            {
                if (id != buyer.BuyerId)
                {
                    return BadRequest("Buyer Id MisMatch");
                }
                var updateid = await this.repo.UpdateById(id, buyer);
                return updateid;
            }
            catch(Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }

        [HttpDelete ("deletebyemail")]
        public async Task<ActionResult>DeleteByEmail(string email)
        {
            try
            {
                if (email == null)
                {
                    return NotFound($"Buyer with Email ={email} not found");
                }
                this.repo.DeleteByEmail(email);

                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }

        [HttpGet("GetByEmail")]
        public async Task<ActionResult<Buyer>> GetByEmail(string email)
        {
            try
            {
                if (email == null)
                {
                    return NotFound($"Buyer with Email ={email} not found");
                }

                var res = await this.repo.GetByEmail(email);
                return res;
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }
        }

        [HttpPost("login")]
        public ActionResult<Buyer> Login(String email, String password)
        {
            
            try
            {
                if (email == null || password== null)
                {
                    return NotFound();
                }

                var res =  this.repo.Login(email, password);
                return res;
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }



        /*
                [HttpPost("login2")]
                public async Task<ActionResult<Buyer>> Login2(string email, string password)
                {

                    string UserName = email;

                    string Password = password;

                    var byteArray = Encoding.ASCII.GetBytes($"{
                        UserName}: {Password}"); var clientAuthrizationHeader = new AuthenticationHeaderValue("Basic",

        Convert.ToBase64String(byteArray));

                        Request.Headers.Add("Authorization", clientAuthrizationHeader.ToString());

                    }
        */

        //[HttpGet("login")]
        //public async Task<ActionResult<Buyer>> Login()
        //{
        //    using CarDekhoDBContext context = new CarDekhoDBContext();

        //    string emailAddress = HttpContext.User.Identity.Name;
        //    var buyer = await context.Buyers
        //         .Where(b => b.BuyerEmail == emailAddress ).FirstOrDefaultAsync();
        //    //buyer.BuyerPassword = null;
        //    if (buyer == null)
        //    {
        //        return this.NotFound();
        //    }
        //    return Ok();
        //}
        [Route("GetAllDetails")]
        [HttpGet]
        public async Task<IEnumerable<Buyer>> GetAll()
        {
            try
            {
                var res = await this.repo.GetAll();
                return res;
            }
            catch(Exception e)
            {
                return (IEnumerable<Buyer>)StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error Receving Data From The Database");
            }

          
        }

       //Car Listing

        //[BasicAuthentication]
        //public bool GetByEmail(string email,string password)
        //{
        //    string mail = Thread.CurrentPrincipal.Identity.Name;

        //        var res =  BuyerSecurity.Login(email,password);
        //        return res;

        //}
    }
    }
