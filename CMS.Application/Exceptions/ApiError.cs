﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Application.Exceptions
{
   public class ApiError
    {
        public bool IsError { get; set; }
        public string ExceptionMessage { get; set; }

        public string Details { get; set; }

        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public ApiError(string message)
        {
            this.ExceptionMessage = message;
            this.IsError = true;
        }
        public ApiError(ModelStateDictionary modelState)
        {
            this.IsError = true;
            if(modelState != null && modelState.Any(m=>m.Value.Errors.Count > 0))
            {
                this.ExceptionMessage = "Please correct the specified model validation errors";
                this.ValidationErrors = modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)));
            }
        }
    }
}
