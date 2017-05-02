using KEYAKI_Suite.KEYAKIBlogService;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

namespace KEYAKI_Suite.UseCase
{
    public class KeyakiBlogListUseCase
    {
        private KEYAKIBlogService.KeyakiBlogService KeyakiBlogService;

        public ReactiveCollection<KEYAKIBlogData> KeyakiBlogDatas { get; set; } = new ReactiveCollection<KEYAKIBlogData>();

        public KeyakiBlogListUseCase(KEYAKIBlogService.KeyakiBlogService keyakiBlogService)
        {
            KeyakiBlogService = keyakiBlogService;
        }

        public async void FetchBlogData()
        {
            var blogList = await KeyakiBlogService.GetBlogData();
            blogList.ForEach(data => KeyakiBlogDatas.Add(data));
        }
    }
}
