

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using AgilityExtension;

namespace KEYAKI_Suite.MatomeService
{
    public class KEYAKIMatomeService
    {

        public async Task<List<KEYAKIMatomeData>> GetMatomeData()
        {
            var url = GetKEYAKIMatomeURL();
            var htmlText = await GetKEYAKIMatomehtmlAsync(url);
            return AnalyzeHTML(htmlText);
        }

        private string GetKEYAKIMatomeURL() => "http://2ch.0726.biz/matome_search?keyword=%E6%AC%85%E5%9D%8246";

        private List<KEYAKIMatomeData> AnalyzeHTML(string html)
        {
            if (string.IsNullOrWhiteSpace(html)) return null;

            var htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.LoadHtml(html);

            var matomeList = htmldoc.DocumentNode
                .Descendants("li")
                .Where(node => node.GetAttributeValue("class", "") == "arw");



            return matomeList.Select(node =>
                {
                    var Title = node
                        .Descendants("span")
                        .Single(htmlNode => htmlNode.GetAttributeValue("class", "") == "title")
                        .InnerText;

                    var posturl = node
                        .Descendants("a").Single()
                        .GetAttributeValue("href", "");

                    var postsite = node
                        .Descendants("span")
                      .Single(htmlNode => htmlNode.GetAttributeValue("class", "") == "site")
                      .InnerText;

                    var postTimeText = node
                            .Descendants("span")
                            .Single(htmlNode => htmlNode.GetAttributeValue("class", "") == "data")
                            .InnerText;

                    var postyear = postTimeText.Substring(0, 4);
                    var postmonth = postTimeText.Substring(5, 2);
                    var postday = postTimeText.Substring(8, 2);
                    var posthour = postTimeText.Substring(11, 2);
                    var postminutes = postTimeText.Substring(14, 2);
                    var postsecound = postTimeText.Substring(17, 2);

                    var posttime = new DateTime(int.Parse(postyear), int.Parse(postmonth), int.Parse(postday),
                        int.Parse(posthour), int.Parse(postminutes), int.Parse(postsecound));

                    return new KEYAKIMatomeData
                    {
                        Title = Title,
                        PostSite = postsite,
                        PostURL = posturl,
                        PostTime = posttime
                    };
                })
                .ToList();

        }

        private async Task<string> GetKEYAKIMatomehtmlAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return "";
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync(url);
                var html = await result.Content.ReadAsStringAsync();
                return html;
            }
        }
    }
}
