using static RhommieBank.Web.Util.SD;

namespace RhommieBank.Web.Models
{
    public class RequestDto
    {
        public RequestDto()
        {
            ApiType = ApiType.GET;
        }
        public ApiType ApiType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
