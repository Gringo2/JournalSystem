using Journal.web.Models;
using Microsoft.AspNetCore.Http;
using System;

namespace Journal.web.Extensions
{
    public static class RequestCookieCollection
    {
        public static Guid GetCurrentCartId(this IRequestCookieCollection cookies, Settings settings)
        {
            Guid.TryParse(cookies[settings.CartIdCookieName], out Guid cartId);
            return cartId;
        }
    }
}
