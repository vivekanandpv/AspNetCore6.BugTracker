using AspNetCore6.BugTracker.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6.BugTracker.Filters;

public class GeneralExceptionHandlerFilter : IActionFilter, IOrderedFilter {
    public int Order => Int32.MaxValue - 10;
        
    public void OnActionExecuted(ActionExecutedContext context) {
        if (context.Exception is RecordNotFoundException 
            || context.Exception is DomainInvariantException) {
            context.Result = new ObjectResult(new {
                context.Exception.Message
            }) {
                StatusCode = 400
            };

            context.ExceptionHandled = true;
        }

        if (context.Exception is LoginFailedException) {
            context.Result = new ObjectResult(new {
                context.Exception.Message
            }) {
                StatusCode = 401
            };

            context.ExceptionHandled = true;
        }

        if (context.Exception is OperationNotSupportedException) {
            context.Result = new ObjectResult(new {
                context.Exception.Message
            }) {
                StatusCode = 403
            };

            context.ExceptionHandled = true;
        }

        if (!context.ExceptionHandled && context.Exception != null) {
            context.Result = new OkObjectResult(new {
                context.Exception.Message
            }) {
                StatusCode = 503
            };
                
            context.ExceptionHandled = true;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context) {
            
    }
}