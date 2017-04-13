using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;


namespace KEYAKI_Suite.Model
{
    public class KEYAKINewsModel
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

                var node = htmldoc.DocumentNode
                    .Elements("/html[1]/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[2]/ul[1]/li");
                var list = node.Select(htmlNode =>
               {
                   var Text = htmlNode.Element("/div[1]").InnerText;
                   var ImagePath =
                       "https://cdn.image.st-hatena.com/image/square/89cab2c1363c2df21ee4c6928fe6bb5457098ae0/backend=imagemagick;height=40;version=1;width=40/http%3A%2F%2Ff.st-hatena.com%2Fimages%2Ffotolife%2Fc%2Fch3cooh393%2F20151216%2F20151216123016.png";
                   var Detail = htmlNode.Element("/div[2]").InnerText;
                   return new NewsData { ImagePath = ImagePath, Text = Text, Detail = Detail };
               });
                list.ForEach(data => NewsDatas.Add(data));

            }
        }
    }
}
