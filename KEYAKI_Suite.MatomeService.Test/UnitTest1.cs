using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace KEYAKI_Suite.MatomeService.Test
{
    public class UnitTest1
    {
        private KEYAKIMatomeService MatomeService => new KEYAKIMatomeService();

        [Fact]
        public async Task まとめサイトの情報を取得できているかのテストAsync()
        {
            var url = MatomeService.AsDynamic().GetKEYAKIMatomeURL() as string;
            (await MatomeService.AsDynamic().GetKEYAKIMatomehtmlAsync(url) as string).IsNotNull();
            (await MatomeService.AsDynamic().GetKEYAKIMatomehtmlAsync(url) as string).IsNot("");
        }

        [Fact]
        public async Task まとめサイトから情報を取得しパースで来ているかのテスト()
        {
            var matomeDatas = await MatomeService.GetMatomeData();
            matomeDatas.IsNotNull();
            var matomedata = matomeDatas.First();
            matomedata.PostSite.IsNotNull();
            matomedata.PostTime.ToString().IsNotNull();
            matomedata.PostURL.IsNotNull();
            matomedata.Title.IsNotNull();
        }
    }
}
