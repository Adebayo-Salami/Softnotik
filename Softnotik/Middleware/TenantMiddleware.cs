namespace Softnotik.Middleware
{
    internal sealed class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var host = context.Request.Host.Value;
            var subdomain = host.Split('.')[0];

            // Set the tenant based on the subdomain
            context.Items["Tenant"] = subdomain;

            await _next(context);
        }
    }
}
