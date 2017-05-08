using KEYAKI_Suit.YoutubeService;
using KEYAKI_Suite.UseCase;
using Reactive.Bindings;

namespace KEYAKI_Suite.Native.UWP.ViewModels
{
    public class YoutubePageViewModel
    {
        private readonly KeyakiYoutubeListUseCase _keyakiYoutubeListUseCase;

        public ReactiveCollection<Item> YoutubeItems { get; set; }

        public YoutubePageViewModel(KeyakiYoutubeListUseCase keyakiYoutubeListUseCase)
        {
            _keyakiYoutubeListUseCase = keyakiYoutubeListUseCase;

            YoutubeItems = _keyakiYoutubeListUseCase.YoutubeDatas;

            _keyakiYoutubeListUseCase.FetchYoutubeData();
        }
    }
}
