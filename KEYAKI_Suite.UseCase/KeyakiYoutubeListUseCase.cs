using KEYAKI_Suit.YoutubeService;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

namespace KEYAKI_Suite.UseCase
{
    public class KeyakiYoutubeListUseCase
    {
        private readonly YoutubeService.YoutubeService YoutubeService;

        public ReactiveCollection<Item> YoutubeDatas { get; set; } = new ReactiveCollection<Item>();

        public KeyakiYoutubeListUseCase(YoutubeService.YoutubeService youtubeService)
        {
            YoutubeService = youtubeService;
        }

        public async void FetchYoutubeData()
        {
            var youtubeDatalist = await YoutubeService.GetYoutubeDataAsync();
            youtubeDatalist.items.ForEach(data => YoutubeDatas.Add(data));
        }

        
    }
}
