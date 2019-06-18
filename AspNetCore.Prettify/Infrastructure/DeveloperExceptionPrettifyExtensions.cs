using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace AspNetCore.Prettify.Infrastructure
{
    public static class DeveloperExceptionPrettifyExtensions
    {
        /// <summary>
        /// 开启开发环境异常页面css美化中间件
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseDeveloperExceptionPagePrettify(
            this IApplicationBuilder app)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));

            return app.UseMiddleware<DeveloperExceptionPrettifyMiddleware>();
        }
    }
}
