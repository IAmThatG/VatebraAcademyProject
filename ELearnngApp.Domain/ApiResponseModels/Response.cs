using System;
namespace ELearnngApp.Domain.ApiResponseModels
{
    public class Response
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object Result { get; set; }
    }
}
