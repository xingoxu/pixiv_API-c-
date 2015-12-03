using System;
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
                return null;
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
        public JObject illust_work(string illust_id) 
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
        public List<string> illust_work_originalPicURL(string illust_id)
        {
            var json = illust_work(illust_id);

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
        /// <returns>return IsSuccess</returns>
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
        public JObject my_following_works(int page, int per_page, bool include_stats = true, bool include_sanity_level = true)//关注的人的新作品
        {
            string url = "https://public-api.secure.pixiv.net/v1/me/following/works.json";
            var parameters = new Dictionary<string, object>{
               {"page",page},
               {"per_page", per_page},
               {"image_sizes","px_128x128,px_480mw,large"},
               {"include_stats",include_stats},//score and score count
               {"include_sanity_level",include_sanity_level}//unknown
            };

            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }
        public JObject my_favourite_works(int page,int per_page,bool IsPublic)//收藏夹作品
        {
            string url = "https://public-api.secure.pixiv.net/v1/me/favorite_works.json";
            string publicity = "private";
            if (IsPublic) publicity = "public";
            var parameters = new Dictionary<string, object>{
               {"page",page},
               {"per_page", per_page},
               {"image_sizes","px_128x128,px_480mw,large"},
               {"publicity",publicity }
            };

            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }
        public bool my_favourite_work_add(string work_id,bool ispublic)
        {
            string url = "https://public-api.secure.pixiv.net/v1/me/favorite_works.json";
            string publicity = "private";
            if (ispublic) publicity = "public";
            var parameters = new Dictionary<string, object>{
               {"work_id",work_id},
               {"publicity", publicity}
            };

            var task = oauth.HttpPostAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return false;
            }

            return true;
        }
        public bool my_favourite_works_delete(string favourite_ids)//原API上注明需要输入publicity参数，经测试无需输入，都可以删除
        {
            string url = "https://public-api.secure.pixiv.net/v1/me/favorite_works.json";
            var parameters = new Dictionary<string, object>{
               {"ids",favourite_ids}
            };

            var task = oauth.HttpDeleteAsync(url, null, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return false;
            }

            return true;
        }
        public JObject my_following_user(int page,int per_page,bool IsPublic)
        {
            string url = "https://public-api.secure.pixiv.net/v1/me/following.json";
            string publicity = "private";
            if (IsPublic) publicity = "public";
            var parameters = new Dictionary<string, object>{
               {"page",page},
               {"per_page", per_page},
               {"publicity",publicity}
            };

            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }      
        //my_favourite_users api has been removed because of its unexpcted returns
        //public JObject my_favourite_users(int page)//same as my_following_user
        //{
        //    string url = "https://public-api.secure.pixiv.net/v1/me/favorite-users.json";
        //    var parameters = new Dictionary<string, object>()
        //    {
        //        {"page",page }
        //    };

        //    var task = oauth.HttpGetAsync(url, parameters);

        //    if (!task.Result.IsSuccessStatusCode)
        //    {
        //        Debug.WriteLine(task.Result);
        //        return null;
        //    }

        //    return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        //}
        public bool my_favourite_user_follow(string user_id,bool IsPublic)
        {
            string url = "https://public-api.secure.pixiv.net/v1/me/favorite-users.json";
            string publicity = "private";
            if (IsPublic) publicity = "public";
            var parameters = new Dictionary<string, object>()
            {
                {"target_user_id",user_id },
                {"publicity" ,publicity}
            };

            var task = oauth.HttpPostAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return false;
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="author_ids">can put more than 2 id at here, use ',' to split them</param>
        /// <returns></returns>
        public bool my_favourite_users_unfollow(string user_ids)
        {
            string url = "https://public-api.secure.pixiv.net/v1/me/favorite-users.json";
            var parameters = new Dictionary<string, object>
            {
                {"delete_ids",user_ids }
            };

            var task = oauth.HttpDeleteAsync(url, null, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return false;
            }
            return true;
        }
        public JObject user_works(string user_id, int page, int per_page, bool include_stats = true, bool include_sanity_level = true)
        {
            string url = string.Format("https://public-api.secure.pixiv.net/v1/users/{0}/works.json", user_id);

            var parameters = new Dictionary<string, object>{
               {"page",page},
               {"per_page", per_page},
               {"image_sizes","px_128x128,px_480mw,large"},
               {"include_stats",include_stats},//score and score count
               {"include_sanity_level",include_sanity_level}//unknown
            };

            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }
        public JObject user_favourite_works(string user_id,int page,int per_page)
        {
            string url = string.Format("https://public-api.secure.pixiv.net/v1/users/{0}/favorite_works.json", user_id);

            var parameters = new Dictionary<string, object>{
               {"page",page},
               {"per_page", per_page},
               {"image_sizes","px_128x128,px_480mw,large"},
               {"include_sanity_level",true}//unknown
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
        /// 用户活动
        /// </summary>
        /// <param name="author_id"></param>
        /// <param name="show_r18"></param>
        /// <param name="max_id">start from illust_id (can be null)</param>
        /// <returns></returns>
        public JObject user_feeds(string user_id,bool show_r18,string max_id)
        {
            string url = string.Format("https://public-api.secure.pixiv.net/v1/users/{0}/feeds.json", user_id);

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
        public JObject user_following_users(string user_id,int page,int per_page)
        {
            string url = string.Format("https://public-api.secure.pixiv.net/v1/users/{0}/following.json", user_id);
            var parameters = new Dictionary<string, object>()
            {
                {"page",page },
                {"per_page",per_page }
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
        /// ranking_type and mode, are must values and not allow null.
        /// </summary>
        /// <param name="ranking_type">all,illust,manga,ugoira(gif/动图)</param>
        /// <param name="mode">about mode please see documents</param>
        /// <param name="page"></param>
        /// <param name="per_page"></param>
        /// <param name="date">format:yyyy-MM-dd</param>
        /// <returns></returns>
        public JObject ranking(string ranking_type,string mode,int page,int per_page,string date)
        {            
            string url = string.Format("https://public-api.secure.pixiv.net/v1/ranking/{0}.json", ranking_type);
            var parameters = new Dictionary<string, object>()
            {
                {"mode",mode },
                {"page",page },
                {"per_page",per_page },
                {"include_stats",true },
                {"include_sanity_level",true },
                {"image_sizes","px_128x128,px_480mw,large"},
                {"profile_image_sizes","px_170x170,px_50x50" }
            };
            if (date != null) parameters.Add("date", date);

            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }
        /// <summary>
        /// search api only sort with date
        /// </summary>
        /// <param name="query">query string</param>
        /// <param name="page">1-n</param>
        /// <param name="per_page"></param>
        /// <param name="mode">[text,tag,caption,exact_tag] text means title/caption</param>
        /// <param name="period">[all,day,week,month]</param>
        /// <param name="order">[desc,asc] desc(new to old),asc(old to new)</param>
        /// <param name="sort">just "date"</param>
        /// <param name="show_r18">true or false</param>
        /// <returns></returns>
        public JObject search_works(string query, int page, int per_page, string mode = "text", string period = "all", string order = "desc", string sort = "date", bool include_stats = true, bool include_sanity_level = true,bool show_r18=true)
        {
            string url = "https://public-api.secure.pixiv.net/v1/search/works.json";
            int r18 = 0;
            if (show_r18) r18 = 1;
            var parameters = new Dictionary<string, object>()
            {
                {"q",query },
                {"page",page },
                {"per_page",per_page },
                {"period",period },
                {"order",order },
                {"sort",sort },
                {"mode",mode },
                {"types","illustration,manga,ugoira" },
                {"include_stats",include_stats },
                {"include_sanity_level",include_sanity_level },
                {"image_sizes","px_128x128,px_480mw,large"},
                {"show_r18",r18}
            };

            var task = oauth.HttpGetAsync(url, parameters);

            if (!task.Result.IsSuccessStatusCode)
            {
                Debug.WriteLine(task.Result);
                return null;
            }

            return JObject.Parse(task.Result.Content.ReadAsStringAsync().Result);
        }

        public JObject latest_works(int page = 1, int per_page = 30,bool include_stats=true,bool include_sanity_level=true)
        {
            string url = "https://public-api.secure.pixiv.net/v1/works.json";
            var parameters = new Dictionary<string, object>()
            {
                {"page",page },
                {"per_page",per_page },
                {"include_stats",include_stats },
                {"include_sanity_level",include_sanity_level },
                {"image_sizes","px_128x128,px_480mw,large"},
                {"profile_image_sizes","px_170x170,px_50x50" }
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
