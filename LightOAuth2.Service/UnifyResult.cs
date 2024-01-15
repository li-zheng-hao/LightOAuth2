using System.Text.Json.Serialization;

namespace LightOAuth2.Service
{
    public class UnifyResult
    {
        [JsonIgnore]
        public bool IsSuccess { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }


        [JsonIgnore]
        public object Data { get; set; }

        public static UnifyResult Success()
        {
            return new UnifyResult
            {
                IsSuccess = true
            };
        }

        public static UnifyResult Fail(int code, string message)
        {
            return new UnifyResult
            {
                IsSuccess = false,
                Code = code,
                Message = message
            };
        }

        public static UnifyResult Fail(string message)
        {
            return new UnifyResult
            {
                IsSuccess = false,
                Code = 400,
                Message = message
            };
        }
    }


    public class UnifyResult<T>
    {
        [JsonIgnore]
        public bool IsSuccess { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }

        [JsonIgnore]
        public T? Data { get; set; }

        public static UnifyResult<T> Success(T data)
        {
            return new UnifyResult<T>
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static UnifyResult<T> Success()
        {
            return new UnifyResult<T>
            {
                IsSuccess = true
            };
        }

        public static UnifyResult<T> Fail(int code, string message)
        {
            return new UnifyResult<T>
            {
                IsSuccess = false,
                Code = code,
                Message = message
            };
        }

        public static UnifyResult<T> Fail(string message)
        {
            return new UnifyResult<T>
            {
                IsSuccess = false,
                Code= 400,
                Message = message
            };
        }
    }
}
