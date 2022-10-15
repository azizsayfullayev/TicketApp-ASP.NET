namespace TicketApp.WebApi.Commons.Helpers
{
    public class HttpContextHelpers
    {
        public static IHttpContextAccessor Accessor { get; set; } = null!;
        public static HttpContext HttpContext => Accessor.HttpContext;
        public static HttpResponse Response => Accessor.HttpContext.Response;

        public static IHeaderDictionary ResponseHeaders => Response.Headers;

        public static long? UserId => GetUserId();
        private static long? GetUserId()
        {
            string value = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Id").Value;

            bool canParse = long.TryParse(value, out long id);
            return canParse ? id : null;
        }
    }
}
