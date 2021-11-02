using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YogaStudio.WebApi.Middleware
{
    public static class YogaStudioExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseYogaStudioExceptionHandler(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<YogaStudioExceptionHandlerMiddleware>();
        }
    }
}
