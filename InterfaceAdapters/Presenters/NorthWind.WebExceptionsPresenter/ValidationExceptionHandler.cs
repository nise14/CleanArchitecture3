using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NorthWind.WebExceptionsPresenter;

public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
{
    public Task Handle(ExceptionContext context)
    {
        var exception = context.Exception as ValidationException;

        StringBuilder builder = new StringBuilder();
        foreach (var failure in exception.Errors)
        {
            builder.AppendLine(string.Format("Property: {0}. Error: {1}", failure.PropertyName, failure.ErrorMessage));
        }

        return SetResult(context, StatusCodes.Status400BadRequest, "Error in data in", builder.ToString());
    }
}