using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace JetSetGo.Authorization;

public class AuthorizeApiKeyAttribute : Attribute, IAsyncActionFilter
{
    private const string ApiKeyHeaderName = "Authorization";
    private const string ApiKey = "test-api-key-authorization";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey) ||
            !ApiKey.Equals(extractedApiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}
