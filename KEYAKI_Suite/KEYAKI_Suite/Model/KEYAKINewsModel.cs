using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using Prism.Mvvm;
using Reactive.Bindings;


namespace KEYAKI_Suite.Model
{
    public class KEYAKINewsModel: BindableBase
    {
        public ReactiveCollection<NewsData> NewsDatas { get; set; } = new ReactiveCollection<NewsData>();

        public async void GetNewsDatas()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://www.keyakizaka46.com/s/k46o/news/list");
                var htmltext = await result.Content.ReadAsStringAsync();
                var htmldoc = new HtmlAgilityPack.HtmlDocument();
                htmldoc.LoadHtml(htmltext);

                var node = htmldoc.DocumentNode.Descendants("div")
                    .First(htmlNode => htmlNode.GetAttributeValue("class", "") == "box-news")
                    .Descendants("ul")
                    .First()
                    .Descendants("li");

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

                    NewsDatas.Add(new NewsData { ImagePath = ImagePath, Text = Text, Detail = Detail, Link = Link});
                });

            }
        }
    }
}
