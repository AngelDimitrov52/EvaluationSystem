using System;
using System.Net;

namespace EvaluationSystem.Application.Models.Exceptions
{
    public class HttpException : Exception
    {
        public HttpException(string exceptionMessage, HttpStatusCode statusCode)
            : base(exceptionMessage)
        {
            StatusCode = statusCode;
        }
        public HttpStatusCode StatusCode { get; set; }
    }
}
