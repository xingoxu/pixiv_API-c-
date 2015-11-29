using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;


namespace pixiv_API
{
    public class OAuth
    {
        public pixivUser user;
        //login start
        public OAuth(string username,string password)
        {
            var parameters = new Dictionary<string, object>
            {
                {"Referer","http://www.pixiv.net/" },//header

                { "client_id", "bYGKuGVw91e0NMfPGp44euvGt59s" },
                {"client_secret", "HP3RmkgAmEGro0gn1x9ioawQE8WMfvLXDz3ZqxpK" },
                {"grant_type" , "password" },
                {"username", username },
                {"password",password }
                //before is data
            };
            var api = "https://oauth.secure.pixiv.net/auth/token";//oauth_url

            http = new HttpClient(new HttpClientHandler() { CookieContainer = new CookieContainer(), UseCookies = true });

            HttpPostAsync(api, parameters).ContinueWith((task) =>
            {
                if (task.Result.IsSuccessStatusCode)
                {
                    var json = JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
                    Debug.WriteLine(json);

                    user = new pixivUser();
                    user.avatar = new string[3];

                    var response = json.Value<JObject>("response");
                   

                    //foreach (JObject x in response)
                    {
                        user.access_token = response["access_token"].ToString();
                        user.expires_time = (int)response["expires_in"];
                        user.refresh_token = response["refresh_token"].ToString();
                        user.id = response["user"]["id"].ToString();
                        user.name = response["user"]["name"].ToString();
                        user.avatar[0] = response["user"]["profile_image_urls"]["px_16x16"].ToString();//0 small
                        user.avatar[1] = response["user"]["profile_image_urls"]["px_50x50"].ToString();//1 middle
                        user.avatar[2] = response["user"]["profile_image_urls"]["px_170x170"].ToString();//2 big
                    }
                }
                else
                {
                    Debug.WriteLine(task.Result);
                }
            });
        }
        public Task<HttpResponseMessage> HttpPostAsync(string api, Dictionary<string, object> parameters)
        {
            var req_header = new Dictionary<string, object>
            {
                {"Referer","http://spapi.pixiv.net/" },//header
                {"User-Agent","PixivIOSApp/5.8.0" }
            };

            if (parameters == null) parameters = new Dictionary<string, object>();
            
            foreach (KeyValuePair<string,object> x in parameters)
            {
                if (req_header.ContainsKey(x.Key)) req_header[x.Key] = x.Value;
                else req_header.Add(x.Key, x.Value);
            }
            parameters = req_header;
                        
            var dict = new Dictionary<string, object>(parameters.ToDictionary(k => k.Key, v => v.Value));

            HttpContent httpContent = null;

            if (dict.Count(p => p.Value.GetType() == typeof(byte[]) || p.Value.GetType() == typeof(System.IO.FileInfo)) > 0)
            {
                var content = new MultipartFormDataContent();

                foreach (var param in dict)
                {
                    var dataType = param.Value.GetType();
                    if (dataType == typeof(byte[])) //byte[]
                    {
                        content.Add(new ByteArrayContent((byte[])param.Value), param.Key, GetNonceString());
                    }
                    else if (dataType == typeof(System.IO.FileInfo))    //本地文件
                    {
                        var file = (System.IO.FileInfo)param.Value;
                        content.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(file.FullName)), param.Key, file.Name);
                    }
                    else /*if (dataType.IsValueType || dataType == typeof(string))*/   //其他类型
                    {
                        content.Add(new StringContent(string.Format("{0}", param.Value)), param.Key);
                    }
                }
                httpContent = content;
            }
            else
            {
                var content = new FormUrlEncodedContent(dict.ToDictionary(k => k.Key, v => string.Format("{0}", v.Value)));
                httpContent = content;
            }
            return http.PostAsync(api, httpContent);
        }
        HttpClient http;
        private string GetNonceString(int length = 8)
        {
            var sb = new StringBuilder();

            var rnd = new Random();
            for (var i = 0; i < length; i++)
            {

                sb.Append((char)rnd.Next(97, 123));

            }
            return sb.ToString();
        }
    }
}
