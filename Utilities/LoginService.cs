using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Addins.Helpers;
using AddinsPremierducts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Addins.Services
{
    public class LoginService
    {
        static readonly Serilog.ILogger log = SerilogClass.Log;
        // static readonly Serilog.ILogger appLogger = SetupLogging.AppLog;
        public static async Task<MessageModel> Login(string url_login, UserModel userModel)
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            using (HttpClient httpClient = new HttpClient())
            {
                var credential = new
                {
                    email = userModel.Email,
                    password = userModel.Password,
                    mac_address = userModel.MacAddress,
                    uid = userModel.UID
                };
                string credentialJson = JsonConvert.SerializeObject(credential);
                var dataLogin = new StringContent(credentialJson, Encoding.UTF8, "application/json");
                try
                {
                    var message = new MessageModel();
                    HttpResponseMessage response = await httpClient.PostAsync(url_login + "/users/takeoff/login", dataLogin);
                    var resString = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Common.SaveUserData(resString);
                        message = new MessageModel()
                        {
                            Status = HttpStatusCode.OK,
                            Message = "Login success!"
                        };
                        log.Debug("Login Success!");
                    }
                    else
                    {
                        JObject json = JObject.Parse(resString);
                        message = new MessageModel()
                        {
                            Status = HttpStatusCode.Unauthorized,
                            Message = json.GetValue("detail").ToString()
                        };
                        log.Debug("Login Fails: "+ json.GetValue("detail").ToString());
                    }
                    return message;

                }
                catch (Exception exception)
                {
                    log.Debug("Login Error: "+ exception.Message);
                    throw exception;                                        
                }
            }
        }
    }
}