using KShop.Core.Domain.Orders.Exceptions;
using KShop.Core.Domain.Shipments.Exceptions;
using System.Net;

namespace KShop.Endpoint.Api.Middlewares;

public class ExceptionMiddleware 
{
    private readonly RequestDelegate next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch(OrderNotFoundException ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
        catch (OrderItemsReqiredException ex)
        {

            await HandleExceptionAsync(httpContext, ex);
        }
        catch (MinPriceLimitException ex)
        {

            await HandleExceptionAsync(httpContext, ex);
        }
        catch (NotValidShopTimeException ex)
        {

            await HandleExceptionAsync(httpContext, ex);
        }
        catch (ZeroQuantityException ex)
        {

            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await context.Response.WriteAsJsonAsync(ex.Message);
    }
}
