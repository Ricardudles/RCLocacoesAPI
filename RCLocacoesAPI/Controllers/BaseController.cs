using com.raizen.PGC.Application.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace RCLocacoes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult InternalErrorResponse(Exception ex)
        {
            var response = new BaseOutput<string>();
            response.AddError(ex.Message);
            return StatusCode(500, response);
        }

        protected IActionResult ValidatorErrorResponse(List<ValidationFailure> errors)
        {
            var response = new BaseOutput<string>();
            errors.ForEach(error =>
            {
                response.AddError(error.ErrorMessage);
            });
            return StatusCode(400, response);
        }
    }
}