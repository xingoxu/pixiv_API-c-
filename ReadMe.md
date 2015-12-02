# pixiv API Encapsulated with C# ![build pass](https://travis-ci.org/xingoxu/pixiv_API-c-.svg?branch=master)
## translate from [pixivpy](https://github.com/upbit/pixivpy)  

## Start with:    
OAuth  
use as:  
OAuth auth=new OAuth(username,password);  

More detail in demo :)  

Require nuget package : [Newtonsoft.Json](http://www.newtonsoft.com/json)

##  APIs
### for all JObject returns may be null  

```csharp  
public List<string> bad_words()  
public JObject illust_works(string illust_id)  
public JObject user_profile(string user_id)   
public JObject my_feeds(bool show_r18, string max_id) //stats and sanity level is true for default  
public JObject my_following_works(int page, int per_page)  
```  
  
All api has been test and the text is at \pixiv_API\api_result\folder (2015-12-2)  

## License:  

Feel free to use, reuse and abuse the code in this project.  
When you use this API, please [accept the term of pixiv](http://www.pixiv.net/terms/?page=term). The author of the API does not take any responsibility.
  
Thanks for the author and the APIfounder! 