namespace CarDekho.Controllers
{
    using CarDekho.Models;
    using CarDekho.Repository;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepo context;
        private readonly IProviderRepo pcontext;

        public AdminController(IAdminRepo context, IProviderRepo pcontext)
        {

            this.context = context;
            this.pcontext = pcontext;

        }



        [Route("AdminGetallBuyer")]
        [HttpGet]
        public async Task<IEnumerable<Buyer>> AdminGetAllBuyer()
        {
            try
            {
                var res = await context.AdminGetAllBuyer();
                return res;
            }
            catch (Exception e)
            {
                return (IEnumerable<Buyer>)StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error Receving Data From The Database");
            }


        }

        [Route("AdminDeleteBuyerbyID")]
        [HttpDelete]

        public async Task<ActionResult> AdminDeleteBuyerById(long id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound($"Buyer with ID ={id} not found");
                }
                this.context.AdminDeleteBuyerById(id);

                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }
        }

        [Route("AdminGetallSeller")]
        [HttpGet]
        public async Task<IEnumerable<Seller>> AdminGetAllSeller()
        {
            try
            {
                var res = await context.AdminGetAllSeller();
                return (IEnumerable<Seller>)res;
            }
            catch (Exception e)
            {
                return (IEnumerable<Seller>)StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error Receving Data From The Database");
            }


        }

        [Route("AdminDeleteSellerbyId")]
        [HttpDelete]
        public async Task<ActionResult> AdminDeleteSellerById(long id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound($"Seller with ID ={id} not found");
                }


                this.context.AdminDeleteSellerById(id);

                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }

        [Route("AdminGetallProvider")]
        [HttpGet]
        public async Task<IEnumerable<Provider>> AdminGetAllProvider()
        {
            try
            {
                var res = await context.AdminGetAllProvider();
                return (IEnumerable<Provider>)res;
            }
            catch (Exception e)
            {
                return (IEnumerable<Provider>)StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Error Receving Data From The Database");
            }


        }

        [Route("AdminDeleteProviderbyId")]
        [HttpDelete]
        public async Task<ActionResult> AdminDeleteProviderById(long id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound($"Provider with ID ={id} not found");
                }


                this.context.AdminDeleteProviderById(id);

                return Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }


        //[Route("ProvdierBuyerDetails")]
        //[HttpGet]

        //public async Task<IQueryable<Provider>> ProviderBuyerDetails()
        //{
        //    try
        //    {
        //        var res = await context.ProviderBuyerDetails();
        //        return res;
        //    }
        //    catch (Exception e)
        //    {
        //        return (IQueryable<Provider>)StatusCode(
        //            StatusCodes.Status500InternalServerError,
        //            "Error Receving Data From The Database");
        //    }


        //}

        //[Route("ProviderApproval")]
        //[HttpPut]

        //public async Task<ActionResult<Provider>> AdminUpdateProviderStatus(long id, Provider provider)
        //{

        //    var updateid = await this.context.AdminUpdateProviderStatus(id, provider);

        //    return updateid;


        //}

        [Route("AdminUpdateNewCarbyId")]
        [HttpPut]

        public async Task<ActionResult<NewCar>> AdminUpdateNewCarById(long id, NewCar newcar)
        {
            try
            {
              
                if (id != newcar.NewCarId)
                {
                    return BadRequest("New Car Id MisMatch");
                }

                var updateid = await this.context.AdminUpdateNewCarById(id, newcar);
                return updateid;
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }

        [Route("AdminUpdateUsedCarById")]
        [HttpPut]
        public async Task<ActionResult<UsedCar>> AdminUpdateUsedCarById(int id, UsedCar usedCar)
        {
            try
            {

                if (id != usedCar.UsedCarId)
                {
                    return BadRequest("Used Car Id MisMatch");
                }

                var updateid = await this.context.AdminUpdateUsedCarById(id, usedCar);
                return updateid;
            }
            catch (Exception)
            {
                return this.StatusCode(
                   StatusCodes.Status500InternalServerError,
                   "Error Receving Data From The Database");
            }

        }


    }
}