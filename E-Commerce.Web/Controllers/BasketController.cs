using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTransferObjects.BasketModuleDtos;

namespace E_Commerce.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BasketDTo>> GetBasket (string id)
        {
            var basket =await serviceManager.BasketService.GetBasketAsync(id);
            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<BasketDTo>> CreateOrUpdateBasket(BasketDTo basket)
        {
            var createdOrUpdatedBasket =await serviceManager.BasketService.CreateOrUpdateBasketAsync(basket);
            return Ok(basket);
        }
        [HttpDelete("{Key}")]
        public async Task<ActionResult<bool>> DeleteBasket(string Key)
        {
            var Result =await serviceManager.BasketService.DeleteBasketAsync(Key);
            return Ok(Result);
        }
    }
}
