namespace FormulaOneDemo.Middleware;

public class PrintHelloMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("Hello, it's the custom middleware that is about to pass the context to the next middleware!");
        await next(context);
        Console.WriteLine("It's the custom middleware, the response is on its way back up the middleware chain, goodbye!");
    }
}