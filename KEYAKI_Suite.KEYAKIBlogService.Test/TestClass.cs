using System.Collections.Generic;
using NUnit.Framework;
using System.Threading.Tasks;


namespace KEYAKI_Suite.KEYAKIBlogService.Test
{
    [TestFixture]
    public class TestClass
    {
        private KeyakiBlogService KeyakiBlogService => new KeyakiBlogService();

        [Test]
        public async Task 欅坂46のブログからHTMLを取得できているか()
        {
            (await KeyakiBlogService.GetBlogData() as List<KEYAKIBlogData>).IsNotNull();
        }

        [Test]
        public void 欅坂46のブログURLが正常に作成されているかのテスト()
        {
            (KeyakiBlogService.AsDynamic().GenerateKEYAKIBlogURL(0,25) as string).IsNot("");
            (KeyakiBlogService.AsDynamic().GenerateKEYAKIBlogURL(0,25) as string).IsNotNull();
        }

        [Test]
        public async Task 正常に欅坂46のブログからデータを取得できているかのテスト()
        {
            var url = (KeyakiBlogService.AsDynamic().GenerateKEYAKIBlogURL(0, 25) as string);
            (await KeyakiBlogService.AsDynamic().GetKEYAKIBLoghtmlAsync(url) as string).IsNot("");
            (await KeyakiBlogService.AsDynamic().GetKEYAKIBLoghtmlAsync(url) as string).IsNotNull();
        }
    }
}
