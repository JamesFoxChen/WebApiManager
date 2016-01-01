using System.Web.Http;
using WebApiManager.WebApi.Filters;
using WebApiManager.WebApi.Models.Request;
using WebApiManager.WebApi.Models.Response;

namespace WebApiManager.WebApi.Controllers
{
    //[RequestParameterValidation]
    [APIExceptionFilter]
    public class HomeController : ApiController
    {
        [HttpPost]
        [Route("v1/home/test")]
        public BaseResponse Index([FromBody] IndexRequest request)
        {
            var response = new BaseResponse();
            response.Code = 1;
            response.Message = "成功!";

            return response;
        }


        [Route("v1/home/get")]
        public void Get()
        {

        
        }
    }
}
