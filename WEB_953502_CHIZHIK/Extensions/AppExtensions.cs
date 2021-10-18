using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_CHIZHIK.Middleware;

namespace WEB_953502_CHIZHIK.Extensions
{
    public static class AppExtensions
    {
        public static IApplicationBuilder UseFileLogging(this IApplicationBuilder app) => app.UseMiddleware<LogMiddleware>();
    }
}
