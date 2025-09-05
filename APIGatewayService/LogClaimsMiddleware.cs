namespace APIGatewayService
{
    public class LogClaimsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogClaimsMiddleware> _logger;

        public LogClaimsMiddleware(RequestDelegate next, ILogger<LogClaimsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var claims = context.User.Claims;
            foreach (var claim in claims)
            {
                _logger.LogInformation($"Claim type: {claim.Type}, value: {claim.Value}");
            }

            await _next(context);
        }
    }

}
