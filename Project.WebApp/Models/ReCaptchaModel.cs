using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Project.WebApp.Models
{
    public class ReCaptchaModel 
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }

        public bool Result { get; set; }
        public string Message { get; set; }
    }
}