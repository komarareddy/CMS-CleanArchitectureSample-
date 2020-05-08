using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Application.Exceptions
{
    public class ValidationError
    {
        [JsonProperty(NullValueHandling =NullValueHandling.Ignore)]
        public string Field { get; }
        public string Message { get; }
        public ValidationError(string field,string message)
        {
            this.Field = field != string.Empty ? field : null;
            this.Message = message;
        }
    }
}
