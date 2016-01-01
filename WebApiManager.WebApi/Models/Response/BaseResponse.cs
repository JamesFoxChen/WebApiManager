using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiManager.WebApi.Models.Response
{
    public class BaseResponse
    {
        public string RequestId { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }
    }
}