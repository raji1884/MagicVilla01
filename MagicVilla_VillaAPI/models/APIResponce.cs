using System.Net;

namespace MagicVilla_VillaAPI.models
{
    public class APIResponce
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List <string> ErrorMessage { get; set; }
        public object Result { get; set; }
    }
} 
