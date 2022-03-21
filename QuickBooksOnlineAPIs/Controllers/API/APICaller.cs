using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Script.Serialization;
using QuickBooksOnlineAPIs.Models;
namespace QuickBooksOnlineAPIs.Controllers.API
{
    public class APICaller
    {
        public void PostApiCallService(object RequestObj, string httpWebRequestobj)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(httpWebRequestobj);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "Post";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + ConfigurationManager.AppSettings["AccessToken"]);
                httpWebRequest.Accept = "application/json";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JavaScriptSerializer().Serialize(RequestObj);

                    streamWriter.Write(json);
                }

                string result = "";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("401"))
                {
                    RefreshToken();
                    PostApiCallService(RequestObj, httpWebRequestobj);
                }
            }
        }

        string GetApiCallService(string httpWebRequestobj)
        {
            string result = "";

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(httpWebRequestobj);

                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + ConfigurationManager.AppSettings["AccessToken"]);
                httpWebRequest.Accept = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("401"))
                {
                    RefreshToken();
                    result = GetApiCallService(httpWebRequestobj);
                }
            }
            return result;
        }

        public void RefreshToken()
        {
            string httpWebRequestobj = "https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer";

            var nvc = new Dictionary<string, string>();
            nvc.Add("grant_type", "refresh_token");
            nvc.Add("refresh_token", ConfigurationManager.AppSettings["RefreshToken"]);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["AuthRefreshToken"]);


                HttpResponseMessage response = client.PostAsync(httpWebRequestobj, new FormUrlEncodedContent(nvc)).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                var RefreshTokenResp = JsonConvert.DeserializeObject<RefreshTokenResp>(result);

                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings["AccessToken"].Value = RefreshTokenResp.access_token;
                config.Save();

                ConfigurationManager.AppSettings.Set("AccessToken", RefreshTokenResp.access_token);
            }
        }
        public string Query(string query)
        {
            string httpWebRequest = ConfigurationManager.AppSettings["SandboxBaseURL"] + "/v3/company/" + ConfigurationManager.AppSettings["CompanyID"] + "/query?query=" + query + "&minorversion=" + ConfigurationManager.AppSettings["minorversion"];
            string response = GetApiCallService(httpWebRequest);
            return response;
        }

        public void GetAccessToken()
        {
            string httpWebRequestobj = "https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer";

            var nvc = new Dictionary<string, string>();
            nvc.Add("grant_type", "authorization_code");
            nvc.Add("code", ConfigurationManager.AppSettings["AuthorizationCode"]);
            nvc.Add("redirect_uri", ConfigurationManager.AppSettings["RedirectURI"]);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", ConfigurationManager.AppSettings["AuthRefreshToken"]);


                HttpResponseMessage response = client.PostAsync(httpWebRequestobj, new FormUrlEncodedContent(nvc)).Result;
                var result = response.Content.ReadAsStringAsync().Result;

                var AccessTokenObj = JsonConvert.DeserializeObject<AccessTokenResp>(result);

                var config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                config.AppSettings.Settings["AccessToken"].Value = AccessTokenObj.access_token;
                config.AppSettings.Settings["RefreshToken"].Value = AccessTokenObj.refresh_token;
                config.AppSettings.Settings["IdToken"].Value = AccessTokenObj.id_token;
                config.Save();

                ConfigurationManager.AppSettings.Set("AccessToken", AccessTokenObj.access_token);
            }
        }
    }
}