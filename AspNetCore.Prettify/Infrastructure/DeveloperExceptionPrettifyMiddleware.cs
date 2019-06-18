using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.Prettify.Infrastructure
{
    /// <summary>
    /// 开发环境异常页面css美化 中间件
    /// </summary>
    public class DeveloperExceptionPrettifyMiddleware
    {
        private readonly RequestDelegate _next;

        public DeveloperExceptionPrettifyMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Response.StatusCode == 500) // 通过 StatusCode 判断程序报错
            {
                using (TextWriter output = (TextWriter)new StreamWriter(context.Response.Body,
                    new UTF8Encoding(false, true), 4096, true))
                {
                    // 美化版 css/js
                    var chars = @"
                        <style>
                            body{ color: inherit}
                            h1{color:red}
                            h3{color:inherit}
                            .titleerror{color:maroon}
                            body .location{ }
                            #header li{color:blue}
                            #header .selected{background:#44525e}
                            #stackpage .source ol li{background-color:#ffffcc}
                            #stackpage .source ol.collapsible li span{color:#000}
                            .rawExceptionStackTrace{background-color:#ffffcc; padding:.5rem}
                            :focus{outline:none}
                            .showRawException{color:blue}
                        </style>
                        <script>
                            document.querySelector('.expandCollapseButton').click()
                        </script>
                ".ToCharArray();

                    // 输出到响应流中
                    await output.WriteAsync(chars, 0, chars.Length);
                    await output.FlushAsync();
                }
            }
        }
    }
}
