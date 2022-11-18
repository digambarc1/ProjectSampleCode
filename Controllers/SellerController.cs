namespace CarDekho.Controllers
{
    using CarDekho.Models;
    using CarDekho.Repository;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerRepo scc;
        private readonly IUsedCarRepo usedCarrepo;

        public SellerController(ISellerRepo scc, IUsedCarRepo usedCarrepo)
        {
            this.scc = scc;
            this.usedCarrepo = usedCarrepo;
        }

        [HttpPost]
        public async Task<ActionResult<Seller>> Create(Seller u)
        {
            try
            {
                if (u == null)
                {
                    return this.BadRequest();
                }

                var createSeller = this.Ok(await this.scc.Create(u));
                return createSeller;
            }
            catch (Exception)
            {
                return this.StatusCode(
                  StatusCodes.Status500InternalServerError,
                  "Error Receving Data From The Database");
            }
            return this.Ok(await this.scc.Create(u));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seller>> GetById(long id)
        {
            var res = await this.scc.GetById(id);
            try
            {
                if (res == null)
                {
                    return this.NotFound();
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
            try
            {
                if (id == null)
                {
                    return NotFound($"Seller with ID ={id} not found");
                }


                this.scc.DeleteById(id);

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
        public void UpdateById(long id, Seller seller)
        {
            this.scc.UpdateById(id, seller);
        }

        [HttpPost("login")]
        public ActionResult<Seller> Login(string email, string password)
        {
            /* var res = await this.repo.Login(email, password);
             return res;*/

            try
            {
                if (email == null || password == null)
                {
                    return NotFound();
                }

                var res =  this.scc.Login(email, password);
                return res;
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }


        //used car

        [Route("createusedcar")]
        [HttpPost]
        public async Task<ActionResult<UsedCar>> CreateUsedCar(UsedCar u)
        {
          
            try
            {
                if (u == null)
                {
                    return this.BadRequest();
                }

                var createusedcar = this.Ok(await this.usedCarrepo.CreateCar(u));
                return createusedcar;
            }
            catch (Exception)
            {
                return this.StatusCode(
                  StatusCodes.Status500InternalServerError,
                  "Error Receving Data From The Database");
            }
        }

        [Route("UpdateCarDetails")]
        [HttpPut]
        public async Task UpdateCarDetails(int id, UsedCar usedCar)
        {
             await this.usedCarrepo.UpdateCarDetails(id, usedCar);
        }
    }
}
