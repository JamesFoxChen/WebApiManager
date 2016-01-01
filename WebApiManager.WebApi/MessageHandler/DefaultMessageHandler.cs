using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace WebApiManager.WebApi.MessageHandler
{
    public class DefaultMessageHandler : DelegatingHandler
    {
        private readonly string[] MediaTypes = { "application/json", "application/xml", "application/x-www-form-urlencoded" };

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            #region 业务处理前_统一处理
            var requestTime = DateTime.Now;
            string corrId = string.Format("{0}{1}", DateTime.Now.Ticks, Thread.CurrentThread.ManagedThreadId);
       
            HttpContext.Current.Items["requestid"] = string.Format("{0}{1}", DateTime.Now.Ticks, Thread.CurrentThread.ManagedThreadId);
    
            //var inputStr = "";
            //var requestMessage = await request.Content.ReadAsByteArrayAsync();
            //if (request.Content.Headers.ContentType != null &&
            //        MediaTypes.Contains(request.Content.Headers.ContentType.MediaType))
            //{
            //    inputStr = Encoding.UTF8.GetString(requestMessage);
            //    HttpContext.Current.Items["input"] = inputStr;
            //}

            //await IncommingMessageAsync(request, GetIp(), requestMessage);

            #endregion

            var response = await base.SendAsync(request, cancellationToken);

            #region 业务处理后_统一处理
            //byte[] responseMessage;

            //if (response.IsSuccessStatusCode)
            //    responseMessage = await response.Content.ReadAsByteArrayAsync();
            //else
            //    responseMessage = Encoding.UTF8.GetBytes(response.ReasonPhrase);

            //var ex = HttpContext.Current.Items["ex"] as Exception;
            //await OutgoingMessageAsync(request, response, inputStr, responseMessage, GetIp(), requestTime, ex);
            #endregion

            return response;
        }

        private static string GetIp()
        {
            string result = String.Empty;
            result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(result))
            {
                IPAddress tempIP;
                //可能有代理
                if (result.IndexOf(".") == -1) //没有“.”肯定是非IPv4格式
                    result = null;
                else
                {
                    if (result.IndexOf(",") != -1)
                    {
                        //有“,”，估计多个代理。取第一个不是内网的IP。
                        result = result.Replace("  ", "").Replace("'", "");
                        string[] temparyip = result.Split(",;".ToCharArray());
                        for (int i = 0; i < temparyip.Length; i++)
                        {
                            if (IPAddress.TryParse(temparyip[i], out tempIP)
                                && temparyip[i].Substring(0, 3) != "10."
                                && temparyip[i].Substring(0, 7) != "192.168"
                                && temparyip[i].Substring(0, 7) != "172.16.")
                            {
                                return temparyip[i]; //找到不是内网的地址
                            }
                        }
                    }
                    else if (IPAddress.TryParse(result, out tempIP)) //代理即是IP格式
                        return result;
                    else
                        result = null; //代理中的内容 非IP，取IP 
                }
            }
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.UserHostAddress;

            return result ?? "";
        }

        protected async Task IncommingMessageAsync(HttpRequestMessage request, string ip, byte[] message)
        {
        }

        protected async Task OutgoingMessageAsync(HttpRequestMessage request, HttpResponseMessage response, string inputStr, byte[] message, string ip, DateTime requestTime, Exception ex)
        {
            await Task.Run(() =>
            {
                var outputStr = Encoding.UTF8.GetString(message);
                try
                {
                    //记录请求日志，nosql数据库
                }
                catch (Exception e)
                {
                }
            });
        }
    }
}