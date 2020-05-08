using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CMS.Application.Exceptions
{
    /// <summary>
    /// The APIResponse class is a custom wrapper response object that is used to
    /// provide a consistent data structure for all API responses
    /// </summary>
    [DataContract]
    public class APIResponse
    {
        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember(EmitDefaultValue =false)]
        public ApiError ResponseException { get; set; }

        [DataMember(EmitDefaultValue =false)]
        public object Result { get; set; }

        public APIResponse(int statusCode,string message="", object result=null, ApiError apiError=null,string apiVersion="1.0.0.0")
        {
            this.StatusCode = statusCode;
            this.Message = message;
            this.Result = result;
            this.ResponseException = apiError;
            this.Version = apiVersion;

        }

    }
}
