using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CMS.Application.Exceptions
{
    public enum ResponseMessageEnum
    {
        [Description("Request Successful")]
        Success,
        [Description("Request responded with exceptions.")]
        Exception,
        [Description("Request Denied")]
        UnAuthorized,
        [Description("Request responded with validation errors")]
        ValidationError,
        [Description("Unable to process the request")]
        Failure
    }
}
