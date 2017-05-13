using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AgilityExtension;
using KEYAKI_Suite.Entity;

namespace KEYAKI_Suite.KEYAKIBlogService
{
    public class KeyakiBlogService : IKeyakiBlogService
    {
	    public async Task<IEnumerable<Entity.KEYAKIBlogData>> GetBlogData(int pageNumber = 0, int articleNumber = 25)
	    {
	        var url = GenerateKeyakiBlogUrl(pageNumber,articleNumber);
	        var htmlText = await GetKeyakibLoghtmlAsync(url);
	        return AnalyzeHtml(htmlText);
	    }
        
	    private IEnumerable<Entity.KEYAKIBlogData> AnalyzeHtml(string html)
	    {
	        if (string.IsNullOrWhiteSpace(html)) return null;

	        var htmldoc = new HtmlAgilityPack.HtmlDocument();
	        htmldoc.LoadHtml(html);

	        var blogList = htmldoc.DocumentNode
	            .Descendants("div")
	            .Single(node => node.GetAttributeValue("class", "") == "box-main")
	            .Descendants("article")
	            .ToList();

	        var blogdata = blogList.Select(node =>
	            {
	                var title = node
	                    .ChindSelectByClass("innerHead")
	                    .ChindSelectByClass("box-ttl")
	                    .Descendants("h3").Single()
	                    .Descendants("a").Single()
	                    .InnerText;

	                var dateText = node
	                    .ChindSelectByClass("box-bottom")
	                    .Descendants("ul").Single()
	                    .Descendants("li").Single(htmlNode => htmlNode.GetAttributeValue("class", "") != "singlePage")
	                    .InnerText.Substring(10).Remove(16, 7);

	                var postyears = int.Parse(dateText.Substring(0, 4));
	                var postmanth = int.Parse(dateText.Substring(5, 2));
	                var postdays = int.Parse(dateText.Substring(8, 2));
	                var posthours = int.Parse(dateText.Substring(11, 2));
	                var postminutes = int.Parse(dateText.Substring(14, 2));

	                var postmember = node.Descendants("p").First(htmlNode => htmlNode.GetAttributeValue("class", "") == "name")
	                    .InnerText.Replace("\n", "").TrimStart().TrimEnd();

	                var postdata = new DateTime(postyears, postmanth, postdays, posthours, postminutes, 0);

	                var imageUrl = node.ChindSelectByClass("box-article")
	                    .Descendants("img")
                        .FirstOrDefault()?
	                    .GetAttributeValue("src", "") ?? "http://cdn.keyakizaka46.com/files/14/images/blog/default.jpg";

	                var blogURL = node
	                    .ChindSelectByClass("innerHead")
	                    .ChindSelectByClass("box-ttl")
	                    .Descendants("h3").Single()
	                    .Descendants("a").Single()
                        .GetAttributeValue("href", "");

	                return new Entity.KEYAKIBlogData{ Title = title,PostDatetime = postdata,PostWriter = postmember, ImageURL = imageUrl, URL = blogURL };
	            })
	            .ToList();
	        return blogdata;
	    }

	    private async Task<string> GetKeyakibLoghtmlAsync(string url)
	    {
	        if (string.IsNullOrWhiteSpace(url)) return "";
	        using (var client = new HttpClient())
	        {
	            var result = await client.GetAsync(url);
	            var html = await result.Content.ReadAsStringAsync();
	            return html;
	        }
	    }

	    private string GenerateKeyakiBlogUrl(int pageNumber = 0, int articleNumber = 25)
	    {
	        if (pageNumber < 0 || articleNumber < 0) return "";
	        return $"http://www.keyakizaka46.com/s/k46o/diary/member/list?ima=0000&page={pageNumber}&rw={articleNumber}&cd=member";
	    }
	}
}