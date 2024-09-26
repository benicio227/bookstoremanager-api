using BookStoreManager.Communication.Responses;
using BookStoreManager.Exception;
using BookStoreManager.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStoreManager.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{

    public void OnException(ExceptionContext context)
    {
        if(context.Exception is BookStoreManagerException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var bookStoreManagerException = context.Exception as BookStoreManagerException;
        var errorResponse = new ResponseErrorJson(bookStoreManagerException!.GetErrors());

        context.HttpContext.Response.StatusCode = bookStoreManagerException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        var errorMessage = new ResponseErrorJson(ResourceErrorMessages.UNKNOW_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorMessage);

       
    }
}
