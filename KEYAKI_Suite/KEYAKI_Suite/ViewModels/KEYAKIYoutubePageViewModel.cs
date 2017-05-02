using Prism.Mvvm;
using System;
using System.Reactive.Linq;
using KEYAKI_Suit.YoutubeService;
using KEYAKI_Suite.UseCase;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class KEYAKIYoutubePageViewModel : BindableBase
    {
        private readonly KeyakiYoutubeListUseCase KeyakiYoutubeListUseCase;

        public ReactiveCommand<Item> YoutubeTapCommand { get; set; } = new ReactiveCommand<Item>();

        public ReactiveCollection<Item> YoutubeItems { get; set; }

        public KEYAKIYoutubePageViewModel(KeyakiYoutubeListUseCase keyakiYoutubeListUseCase)
        {
            KeyakiYoutubeListUseCase = keyakiYoutubeListUseCase;


            YoutubeItems = KeyakiYoutubeListUseCase.YoutubeDatas;

            KeyakiYoutubeListUseCase.FetchYoutubeData();

            YoutubeTapCommand
                .Where(o => YoutubeItems.Count != 0)
                .Where(snippet => snippet != null)
                .Subscribe(snippet => Device.OpenUri(new Uri("https://www.youtube.com/watch?v=" + snippet.id.videoId)));
        }
    }
}
