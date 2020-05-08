using CMS.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.API.Filters
{
    /// <summary>
    /// Introduce Model state auto validation to reduce code duplication
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var modelState = context.ModelState;
            if (!modelState.IsValid)
            {
                ApiError errors = new ApiError(modelState);
                APIResponse response = new APIResponse(400, "Model Validation errors", null, errors);
                context.Result = new BadRequestObjectResult(response);
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
