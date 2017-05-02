using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;

namespace KEYAKI_Suite.KEYAKINewsService
{
    public class KEYAKINewsService
	{

	    public async Task<List<NewsData>> GetNewsData()
	    {
	        var htmltext = await GetHTMLTextAsync();
	        return await ConversionHTML2NewsDataAsync(htmltext);
	    }

	    private async Task<List<NewsData>> ConversionHTML2NewsDataAsync(string htmltext)
	    {
	        var htmldoc = new HtmlAgilityPack.HtmlDocument();
	        htmldoc.LoadHtml(htmltext);

	        var node = htmldoc.DocumentNode.Descendants("div")
	            .First(htmlNode => htmlNode.GetAttributeValue("class", "") == "box-news")
	            .Descendants("ul")
	            .First()
	            .Descendants("li");

	        var NewsDatas = new List<NewsData>();

	        node.ForEach(htmlNode =>
	        {
	            var Detail = htmlNode.Descendants("div")
	                .First(node1 => node1.GetAttributeValue("class", "").Contains("category"))
	                .InnerText;

	            var Text = htmlNode.Descendants("div")
	                .First(node1 => node1.GetAttributeValue("class", "") == "text")
	                .Descendants("a")
	                .First()
	                .InnerText;

	            var Link = htmlNode.Descendants("div")
	                .First(node1 => node1.GetAttributeValue("class", "") == "text")
	                .Descendants("a")
	                .First()
	                .GetAttributeValue("href", "");

	            var ImagePath = "http://design-ec.com/d/e_others_50/l_e_others_501.png";

	            NewsDatas.Add(new NewsData { ImagePath = ImagePath, Text = Text, Detail = Detail, Link = "http://www.keyakizaka46.com/" + Link });
	        });

	        return NewsDatas;
	    }

	    private async Task<string> GetHTMLTextAsync()
	    {
	        using (var client = new HttpClient())
	        {
	            var response = await client.GetAsync("http://www.keyakizaka46.com/s/k46o/news/list");
	            var html = await response.Content.ReadAsStringAsync();
	            return html ?? "";
	        }
	    }

    }
}
