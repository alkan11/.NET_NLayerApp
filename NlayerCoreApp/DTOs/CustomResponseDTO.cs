using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NlayerCoreApp.DTOs
{
    public class CustomResponseDTO<T>
    {
        public T Data { get; set; }
        public List<String>? Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CustomResponseDTO<T> Success(int statusCode,T Data)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Data = Data };
        }
        public static CustomResponseDTO<T> Success(int statusCode)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode };
        }
        public static CustomResponseDTO<T> Fail(int statusCode,List<String> errors)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode,Errors=errors };
        }
        public static CustomResponseDTO<T> Fail(int statusCode, string errors)
        {
            return new CustomResponseDTO<T> { StatusCode = statusCode, Errors = new List<String> { errors} };
        }
    }
}
