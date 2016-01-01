using System.Web.Http.Filters;

namespace WebApiManager.WebApi.Filters
{
    public class APIExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //var ex = context.Exception;
            //var argument = ""; //context.ActionContext.ActionArguments.ToJson();  请求参数转换成json格式
            //var action = context.ActionContext.ActionDescriptor.ActionName;
            //var controller = context.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
            //var error = string.Format(@"\r\nController:[{0}]\r\nAction:[{1}]\r\nArgument:{2}\r\nMessage:{3}\r\nStackTrace:{4}", 
            //    controller, action, argument, ex.Message, ex.StackTrace);
            //HttpContext.Current.Items["ex"] = ex;
         
            ////error 信息写入日志
            
            ////返回异常信息
            //var result = new BaseResponse();
            //result.Code = -1;
            //result.Message = context.Exception.Message;
            //result.RequestId = HttpContext.Current.Items["requestid"].ToString();

            //context.Response = context.Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}