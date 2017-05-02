using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

namespace KEYAKI_Suite.UseCase
{
    public class KeyakiNewsListUseCase
    {
        private readonly KEYAKINewsService.KEYAKINewsService _keyakiNewsService;
        
        public ReactiveCollection<NewsData> NewsDatas { get; set; }= new ReactiveCollection<NewsData>();

        public KeyakiNewsListUseCase(KEYAKINewsService.KEYAKINewsService keyakiNewsService)
        {
            _keyakiNewsService = keyakiNewsService;
        }

        public async void FetchNewsDatasAsync()
        {
            var newsdataList = await _keyakiNewsService.GetNewsData();
            newsdataList.ForEach(data => NewsDatas.Add(data));
        }
    }
}
