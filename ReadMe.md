# pixiv API Encapsulated with C# [![build pass](https://travis-ci.org/xingoxu/pixiv_API-c-.svg?branch=master)](https://travis-ci.org/xingoxu/pixiv_API-c-)
### translate from [pixivpy](https://github.com/upbit/pixivpy)  

## Start with OAuth:    
 
OAuth auth=new OAuth(username,password);  

More detail in demo :)  

Require nuget package : [Newtonsoft.Json](http://www.newtonsoft.com/json)

##  APIs  
### Notice:   
1. for all returns may be null(network problem)  
2. for bool returns pixiv json won't tell you failed with what (bad request or has added), just true(added/followed) or false(bad request)  
3. most api parameters has been written in the code note

```csharp  
public List<string> bad_words()  
public JObject illust_works(string illust_id)  
public JObject user_profile(string user_id)   
public JObject my_feeds(bool show_r18, string max_id) //stats and sanity level is true for default  
public JObject my_following_works(int page, int per_page)  
public JObject my_favourite_works(int page,int per_page)
public bool my_favourite_works_add(string work_id,bool ispublic)
public bool my_favourite_works_delete(string favourite_id)
public JObject my_following_user(int page,int per_page,bool IsPublic)
#region Experimental API
public JObject my_favourite_users(int page)//same as my_following_user
public bool my_favourite_users_follow(string user_id,bool IsPublic)
public bool my_favourite_users_unfollow(string author_ids)
#endregion
public JObject user_works(string author_id, int page, int per_page)
public JObject user_favourite_works(string author_id,int page,int per_page)
public JObject user_feeds(string author_id,bool show_r18,string max_id)
public JObject user_following_users(string author_id,int page,int per_page)

///mode: [daily, weekly, monthly, rookie, original, male, female, daily_r18, weekly_r18, male_r18, female_r18, r18g]
///      for 'illust' & 'manga': [daily, weekly, monthly, rookie, daily_r18, weekly_r18, r18g]
///      for 'ugoira': [daily, weekly, daily_r18, weekly_r18]
public JObject ranking(string ranking_type,string mode,int page,int per_page,string date)

public JObject search_works(string query, int page, int per_page, string mode = "text", string period = "all", string order = "desc", string sort = "date", bool include_stats = true, bool include_sanity_level = true,bool show_r18=true)
```  
  
All api has been test and the result text is at ./pixiv_API/api_result folder (2015-12-2)  

## License:  

Feel free to use, reuse and abuse the code in this project.  

When you use this API, please [accept the term of pixiv](http://www.pixiv.net/terms/?page=term). The author of the API does not take any responsibility.
  
Thanks for the author and the APIfounder! 