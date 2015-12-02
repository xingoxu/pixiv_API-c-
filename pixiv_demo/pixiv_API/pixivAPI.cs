﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace pixiv_API
{
    /// <summary>
    /// Caution: 0. JObject Items will return null
    /// </summary>
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
        }
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
        public JObject user_profile(string user_id) 
        {
            string url = "https://public-api.secure.pixiv.net/v1/users/" + user_id + ".json";
            var parameters = new Dictionary<string, object>(){
                {"profile_image_sizes","px_170x170,px_50x50"},
                {"image_sizes","px_128x128,small,medium,large,px_480mw"},
                {"include_stats", 1},
                {"include_profile", 1},
                {"include_workspace", 1},
                {"include_contacts", 1}
            };
            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }
        /// <summary>
        /// Feeds 动态 フィード 
        /// </summary>
        /// <param name="show_r18"></param>
        /// <param name="max_id">start from illust_id</param>
        /// <returns></returns>
        public JObject my_feeds(bool show_r18, string max_id)
        {
            string url = "https://public-api.secure.pixiv.net/v1/me/feeds.json";

            int r18 = 0;
            if (show_r18) r18 = 1;

            var parameters = new Dictionary<string, object>{
                {"relation","all"},
                {"type","touch_nottext"},
                {"show_r18",r18}
            };
            if (max_id != null) parameters.Add("max_id", max_id);

            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }

        public JObject my_following_works(int page, int per_page)
        {
            string url = "https://public-api.secure.pixiv.net/v1/me/following/works.json";
            var parameters = new Dictionary<string, object>{
               {"page",page},
               {"per_page", per_page},
               {"image_sizes","px_128x128,px_480mw,large"},
               {"include_stats",true},
               {"include_sanity_level",true}
            };

            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }





    }
}
