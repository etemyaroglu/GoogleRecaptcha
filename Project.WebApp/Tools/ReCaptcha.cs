using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using Project.WebApp.Models;

namespace Project.WebApp.Tools
{
    public static class ReCaptcha
    {
        public static ReCaptchaModel Check(string response)
        {           
            ReCaptchaModel result = new ReCaptchaModel();
            const string secret = "your secret key here.";
            var client = new WebClient();
            var reply =client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<ReCaptchaModel>(reply);           
            if (!captchaResponse.Success)
            {
                if (captchaResponse.ErrorCodes.Count <= 0)
                {
                    captchaResponse.Result = false;
                    captchaResponse.Message = "Error occured. Please try again";
                    return captchaResponse;
                }
                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        captchaResponse.Result = false;
                        captchaResponse.Message = "The secret parameter is missing.";
                        break;
                    case ("invalid-input-secret"):
                        captchaResponse.Result = false;
                        captchaResponse.Message = "The secret parameter is invalid or malformed.";
                        break;
                    case ("missing-input-response"):
                        captchaResponse.Result = false;
                        captchaResponse.Message = "The response parameter is missing.";
                        break;
                    case ("invalid-input-response"):
                        captchaResponse.Result = false;
                        captchaResponse.Message = "The response parameter is invalid or malformed.";
                        break;
                    default:
                        captchaResponse.Result = false;
                        captchaResponse.Message = "Error occured. Please try again";
                        break;
                }
            }
            else
            {
                captchaResponse.Result = true;
                captchaResponse.Message = "Success";
            }
            return captchaResponse;
        }        
    }
}