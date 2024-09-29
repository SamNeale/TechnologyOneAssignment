using Microsoft.AspNetCore.Mvc;
using TechnologyOneAssignment.Services;

namespace TechnologyOneAssignment
{
    public class NumberController : Controller
    {
        private readonly INumberService _numberService;

        public NumberController(INumberService numberService)
        {
            _numberService = numberService;
        }

        [HttpPost]
        public ActionResult<string> PostDouble(decimal number)
        {
            try
            {
                var outputString = _numberService.ConvertDoubleToStringOfDollarsAndCents(number);
                return CreatedAtAction(nameof(PostDouble), outputString);
            }
            catch (Exception)
            {
                return BadRequest("An error occured trying to convert from a number to a string");
            }
        }
    }
}