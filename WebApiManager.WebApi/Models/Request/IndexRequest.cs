using System.ComponentModel.DataAnnotations;

//ErrorMessage覆盖默认的消息

namespace WebApiManager.WebApi.Models.Request
{
    public class IndexRequest : BaseRequest
    {
        /// <summary>
        /// ID描述信息
        /// </summary>
        [Required(ErrorMessage = "缺少ID")]
        [Range(1,100,ErrorMessage="ID只能在1到100之间")]
        public int ID { get; set; }

        [Required(ErrorMessage = "缺少Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "缺少Age")]
        //[Minimum(18)]
        public string Age { get; set; }

        [Required(ErrorMessage = "缺少Gender")]
        //[Contain("M","F",ErrorMessage="Gender只能是M或F")]
        public string Gender { get; set; }
    }
}