using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Application.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public IEnumerable<ValidationError> Errors { get; set; }

        public ApiException(string message,int statusCode=500,IEnumerable<ValidationError> errors=null,string errorCode="")
        {
            this.StatusCode = statusCode;
            this.Errors = errors;
        }
        public ApiException(Exception ex,int statusCode =500):base(ex.Message)
        {
            StatusCode = statusCode;
        }
    }
}
