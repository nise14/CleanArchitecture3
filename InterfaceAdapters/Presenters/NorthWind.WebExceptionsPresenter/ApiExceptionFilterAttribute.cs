using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NorthWind.WebExceptionsPresenter;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers;

    public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> exceptionHandlers)
    {
        _exceptionHandlers = exceptionHandlers;
    }

    public override void OnException(ExceptionContext context)
    {
        base.OnException(context);

        Type exceptionType = context.Exception.GetType();

        if (_exceptionHandlers.ContainsKey(exceptionType))
        {
            _exceptionHandlers[exceptionType].Handle(context);
        }
        else
        {
            new ExceptionHandlerBase().SetResult(context, StatusCodes.Status500InternalServerError, "Exception occurred processing request", string.Empty);
        }
    }
}