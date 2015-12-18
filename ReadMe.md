# pixiv API Encapsulated with C# [![build pass](https://travis-ci.org/xingoxu/pixiv_API-c-.svg?branch=master)](https://travis-ci.org/xingoxu/pixiv_API-c-)
### translate from [pixivpy](https://github.com/upbit/pixivpy)  

## Start with OAuth:    
```csharp
OAuth auth=new OAuth();  
bool result=await auth.authAsync(username,password);  
if(result) pixivAPI pixivAPI=new pixivAPI(auth);  
```
  
More detail in demo :)  

##Requirements:  
.Net: 4.5 or upper  
nuget package : [Newtonsoft.Json](http://www.newtonsoft.com/json)  
  
##  APIs  
### Update Information:  
Update information are placed at here.  
* [2015-12-19]　update much apis with async method.
* [2015-12-08]　fix a critical bug and found some exception, will be fixed in a few days(method will be replaced with asyncMethod)
* [2015-12-04]　update demo and now base api support task cancel
* [2015-12-03]　update demo and adjust some async method
* [2015-12-03]　update APIs with [pixivpy](https://github.com/upbit/pixivpy)
* 　　　　　　　my_favourite_users api has been removed because of its unexpected returns
* [2015-12-02]　added most of apis

### Notice:   
0. all method now have async method, see it in pixivAPI.cs!
1. for all returns may be null(network problem)  
2. for bool returns pixiv json won't tell you failed with what (bad request or has added), just true(added/followed) or false(bad request)  
3. most api parameters has been written in the code note  
4. if it hasn't, see the following api list with caption  

```csharp  
public List<string> bad_words()  

public JObject illust_work(string illust_id)    
public List<string> illust_work_originalPicURL(string illust_id)  

public JObject user_profile(string user_id)  

public JObject my_feeds(bool show_r18, string max_id)  

/// include_stats is the work's score and score count
/// include_sanity_level is unknown
/// applies to all of the following apis
public JObject my_following_works(int page, int per_page, bool include_stats = true, bool include_sanity_level = true)//关注的人的新作品  

public JObject my_favourite_works(int page,int per_page)//收藏夹作品
public bool my_favourite_work_add(string work_id,bool ispublic)
public bool my_favourite_works_delete(string favourite_ids)//原API上注明需要输入publicity参数，经测试无需输入，都可以删除

public JObject my_following_user(int page,int per_page,bool IsPublic)
public bool my_favourite_user_follow(string user_id,bool IsPublic)
public bool my_favourite_users_unfollow(string user_ids)
  
public JObject user_works(string user_id, int page, int per_page, bool include_stats = true, bool include_sanity_level = true)
public JObject user_favourite_works(string user_id,int page,int per_page)
public JObject user_feeds(string user_id,bool show_r18,string max_id)
public JObject user_following_users(string user_id,int page,int per_page)
  
///mode: [daily, weekly, monthly, rookie, original, male, female, daily_r18, weekly_r18, male_r18, female_r18, r18g]
///      for 'illust' and 'manga': [daily, weekly, monthly, rookie, daily_r18, weekly_r18, r18g]
///      for 'ugoira': [daily, weekly, daily_r18, weekly_r18]
public JObject ranking(string ranking_type,string mode,int page,int per_page,string date)


public JObject search_works(string query, int page, int per_page, string mode = "text", string period = "all", string order = "desc", string sort = "date", bool include_stats = true, bool include_sanity_level = true,bool show_r18=true)

public JObject latest_works(int page = 1, int per_page = 30,bool include_stats=true,bool include_sanity_level=true)
  
public async Task<string> DownloadFileAsync(string strPathName, string strUrl, Dictionary<string, object> header = null, CancellationTokenSource tokensource = null)  
```  
  
[2015-12-02]　All api has been test and the result text is at ./pixiv_API/api_result folder  

## License:  

Feel free to use, reuse and abuse the code in this project.    
  
When you use this API, please [accept the term of pixiv](http://www.pixiv.net/terms/?page=term). The author of the API does not take any responsibility.
  
I'm not a professional C# designer. If you have cooler code, pull request is warmly welcomed!  

Thanks for the author and the APIfounder!   