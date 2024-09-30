using Microsoft.AspNetCore.Mvc;
using TechnologyOneAssignment.Models;
using TechnologyOneAssignment.Services;

namespace TechnologyOneAssignment
{
    [Route("api/number")]
    [ApiController]
    public class NumberController : Controller
    {
        private readonly INumberService _numberService;

        public NumberController(INumberService numberService)
        {
            _numberService = numberService;
        }

        [HttpGet]
        public ActionResult<AnswerDTO> GetStringFromNumber([FromQuery] decimal number)
        {
            try
            {
                var outputString = _numberService.ConvertDoubleToStringOfDollarsAndCents(number);
                AnswerDTO dto = new AnswerDTO { Text = outputString };
                return Ok(dto);
            }
            catch (Exception)
            {
                return BadRequest("An error occured trying to convert from a number to a string");
            }
        }
    }
}