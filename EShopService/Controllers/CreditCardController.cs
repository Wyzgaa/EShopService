using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Application;
using EShop.Domain;
using EShop.Domain.Exceptions;

namespace EShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService _creditCardService;
        public CreditCardController(CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpPost ("validate")]
        public IActionResult ValidateCard([FromBody] string cardNumber)
        {
            try 
            {
                bool isValid = _creditCardService.ValidateCard(cardNumber);
                string cardType = _creditCardService.GetCardType(cardNumber);
                return Ok(new
                {
                    Status = isValid ? "Valid" : "Invalid",
                    Provider = cardType
                });
            }
            catch (CardNumberTooLongException ex)
            {
                return StatusCode(414, ex.Message);
            }
            catch (CardNumberTooShortException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (CardNumberInvalidException ex)
            {
                return StatusCode(406, ex.Message);
            }
        }
    }
}