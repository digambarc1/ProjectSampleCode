namespace CarDekho.Controllers
{
    using CarDekho.Models;
    using CarDekho.Repository;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderRepo repo;
        private readonly INewCarRepo repo2;

        public ProviderController(IProviderRepo repo, INewCarRepo repo2)
        {
            this.repo = repo;
            this.repo2 = repo2;
        }

        [HttpPost]
        public async Task<ActionResult<Provider>> Create(Provider u)
        {

            try
            {
                if (u == null)
                {
                    return this.BadRequest();
                }

                var createProvider = this.Ok(await this.repo.Create(u));
                return createProvider;
            }
            catch (Exception)
            {
                return this.StatusCode(
                  StatusCodes.Status500InternalServerError,
                  "Error Receving Data From The Database");
            }
        }

        [HttpGet]
        public async Task<ActionResult<Provider>> GetById(long id)
        {
            var res = await this.repo.GetById(id);
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
                    return NotFound($"Provider with ID ={id} not found");
                }

                repo.DeleteById(id);

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

        public async Task<ActionResult<Provider>> UpdateById(long id, Provider provider)
        {

                var updateid = await this.repo.UpdateById(id, provider);

                return updateid;
           

        }

        [HttpPost("login")]
        public async Task<ActionResult<Provider>> Login(string email, string password)
        {

            try
            {
                if (email == null || password == null)
                {
                    return NotFound();
                }

                var res = await this.repo.Login(email, password);
                return res;
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }


        // New Car

        [Route("createCar")]
        [HttpPost]
        public async Task<ActionResult<NewCar>> CreateCar(NewCar u)
        {
            try
            {
                if (u == null)
                {
                    return this.BadRequest();
                }
                var createcar = this.Ok(await repo2.CreateCar(u));

                return createcar;
            }
            catch (Exception)
            {
                return this.StatusCode(
                  StatusCodes.Status500InternalServerError,
                  "Error Receving Data From The Database");
            }
            
        }

        [Route("GetByIdCar")]
        [HttpGet]
        public async Task<ActionResult<NewCar>> GetByIdCar(long id)
        {
           
            try
            {
                var res = await this.repo2.GetByIdCar(id);
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

        [Route("DeleteByIdCar")]
        [HttpDelete]
        public async Task<ActionResult> DeleteByIdCar(long id)
        {

            try
            {
                if (id == null)
                {
                    return NotFound($"NewCarId with ID ={id} not found");
                }

                this.repo2.DeleteByIdCar(id);

                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }

        [Route("updatebyidcar")]
        [HttpPut]

        public async Task<ActionResult<NewCar>> updatebyidcar(long id, NewCar newcar)
        {
            try
            {
                if (id != newcar.NewCarId)
                {
                    return BadRequest("provider Id MisMatch");
                }

                var updateid = await this.repo2.UpdateByIdCar(id, newcar);
                return updateid;
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }

        //for admin

        [Route("GetAllCar")]
        [HttpGet]
        public async Task<IEnumerable<NewCar>> GetAll()
        {

            try
            {
                var res = await this.repo2.GetAll();
                return res;
            }
            catch (Exception e)
            {
                return (IEnumerable<NewCar>)this.StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error Receving Data From The Database");
            }

        }

    }
}
