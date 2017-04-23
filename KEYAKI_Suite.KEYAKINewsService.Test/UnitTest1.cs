using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KEYAKI_Suite.KEYAKINewsService.Test
{
    [TestClass]
    public class UnitTest1
    {
        public KEYAKINewsService KeyakiNewsService => new KEYAKINewsService();

        [TestMethod]
        public async Task 欅坂46のニュース情報を取得できるかのテスト()
        {
            var news = await KeyakiNewsService.GetNewsData();
            news.IsNotNull();
            news.Count.IsNot(0);
        }

        [TestMethod]
        public async Task 欅坂46のウェブサイトから取得したデータを変換できるかのテスト()
        {
            var htmltext = await KeyakiNewsService.AsDynamic().GetHTMLTextAsync() as string;
            (await KeyakiNewsService.AsDynamic().ConversionHTML2NewsDataAsync(htmltext) as List<NewsData>).Count.IsNot(0);
        }

        [TestMethod]
        public async Task 欅坂46のウェブサイトからHTMLデータを取得できているかのテスト()
        {
            var htmltext = (await KeyakiNewsService.AsDynamic().GetHTMLTextAsync() as string);
            htmltext.IsNotNull();
            htmltext.IsNot("");
        }
    }
}
