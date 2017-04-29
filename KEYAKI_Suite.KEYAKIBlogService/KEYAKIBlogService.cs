using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AgilityExtension;

namespace KEYAKI_Suite.KEYAKIBlogService
{
    public class KEYAKIBlogService 
	{
	    private List<KEYAKIBlogData> AnalyzeHTML(string html)
	    {
	        if (string.IsNullOrWhiteSpace(html)) return null;

	        var htmldoc = new HtmlAgilityPack.HtmlDocument();
	        htmldoc.LoadHtml(html);

	        var blogList = htmldoc.DocumentNode
	            .Descendants("div")
	            .Single(node => node.GetAttributeValue("class", "") == "box-main")
	            .Descendants("article")
	            .ToList();

	        return blogList.Select(node =>
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

	                return new KEYAKIBlogData{Title = title,PostDatetime = postdata,PostWriter = postmember};
	            })
	            .ToList();
        }

	    private async Task<string> GetKEYAKIBLoghtmlAsync(string url)
	    {
	        if (string.IsNullOrWhiteSpace(url)) return "";
	        using (var client = new HttpClient())
	        {
	            var result = await client.GetAsync(url);
	            var html = await result.Content.ReadAsStringAsync();
	            return html;
	        }
	    }

	    private string GenerateKEYAKIBlogURL(int PageNumber)
	    {
	        if (PageNumber < 0) return "";
	        return "http://www.keyakizaka46.com/s/k46o/diary/member/list?ima=0000&page=" + PageNumber + "&rw=25&cd=member";

	    }
	}
}
