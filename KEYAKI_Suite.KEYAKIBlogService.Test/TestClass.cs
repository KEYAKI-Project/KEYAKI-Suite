using NUnit.Framework;
using System.Threading.Tasks;


namespace KEYAKI_Suite.KEYAKIBlogService.Test
{
    [TestFixture]
    public class TestClass
    {
        private KEYAKIBlogService KeyakiBlogService => new KEYAKIBlogService();

        [Test]
        public void 欅坂46のブログURLが正常に作成されているかのテスト()
        {
            (KeyakiBlogService.AsDynamic().GenerateKEYAKIBlogURL(0) as string).IsNot("");
            (KeyakiBlogService.AsDynamic().GenerateKEYAKIBlogURL(0) as string).IsNotNull();
        }

        [Test]
        public async Task 正常に欅坂46のブログからデータを取得できているかのテスト()
        {
            var url = KeyakiBlogService.AsDynamic().GenerateKEYAKIBlogURL(0) as string;
            (await KeyakiBlogService.AsDynamic().GetKEYAKIBLoghtmlAsync(url) as string).IsNot("");
            (await KeyakiBlogService.AsDynamic().GetKEYAKIBLoghtmlAsync(url) as string).IsNotNull();
        }
    }
}
