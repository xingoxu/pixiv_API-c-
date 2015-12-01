using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace pixiv_API
{
    public class pixivAPI
    {
        private OAuth oauth;
        public pixivAPI(OAuth oauth)
        {
            this.oauth = oauth;
        }
        public List<string> bad_words()
        {
            string url = "https://public-api.secure.pixiv.net/v1.1/bad_words.json";

            //
            var task = oauth.HttpGetAsync(url, null);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return new List<string>();
            }

            var json = JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);

            List<string> result = new List<string>();

            do
            {
                foreach (JObject word in json.Value<JArray>("response"))
                {
                    if (word["word"] == null) continue;
                    result.Add(word["word"].ToString());
                }
                //next cursor shold be add at here(now must be null)
            }
            while (json["next"] != null);

            return result;
        }

        public JObject illust_works(string illust_id)
        {
            string url = ("https://public-api.secure.pixiv.net/v1/works/" + illust_id + ".json");
            var parameters = new Dictionary<string, object>(){
                   {"image_sizes", "px_128x128,small,medium,large,px_480mw" },
                   { "include_stats","true" }
            };

            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }//May return null
        public List<string> illust_works_original(string illust_id)
        {
            var json = illust_works(illust_id);

            if (json == null) return new List<string>();

            List<string> result = new List<string>();
            foreach (JObject response in json.Value<JArray>("response"))//though now it will be only one response
            {

                if (!response["metadata"].HasValues)//illust
                    result.Add(response["image_urls"]["large"].ToString());
                else //优先遍历metadata中的原图
                {
                    if (!(bool)response["is_manga"])//ugoira
                    {
                        result.Add(response["image_urls"]["large"].ToString());
                        result.Add(response["metadata"]["zip_urls"]["ugoira600x600"].ToString());
                    }
                    else// manga
                    {
                        foreach (JObject image in response["metadata"]["pages"].Value<JArray>())
                        {
                            result.Add(image["image_urls"]["large"].ToString());
                        }
                    }
                }
            }
            return result;
        }



    }
}
