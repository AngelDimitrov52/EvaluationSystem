using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Models.Exceptions
{
    public class HttpException : Exception
    {
        public HttpException(string exceptionMessage , HttpStatusCode statusCode)
            :base(exceptionMessage)
        {
            StatusCode = statusCode;
        }
        public HttpStatusCode StatusCode { get; set; }
    }
}
