using KEYAKI_Suite.KEYAKIBlogService;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

namespace KEYAKI_Suite.Repositry
{
    public class KeyakiBlogDataRepositry
    {
        public ReactiveCollection<KEYAKIBlogData> KeyakiBlogDatas { get; set; } = new ReactiveCollection<KEYAKIBlogData>();

        public KeyakiBlogDataRepositry()
        {
            GetBlog();
        }

        private async void GetBlog()
        {
            var blogService = new KeyakiBlogService();
            var blogList = await blogService.GetBlogData();
            blogList?.ForEach(data => KeyakiBlogDatas.Add(data));
        }
    }
}
