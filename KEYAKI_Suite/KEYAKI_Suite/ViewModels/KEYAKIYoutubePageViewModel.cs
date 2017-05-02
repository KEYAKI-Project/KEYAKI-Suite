using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using KEYAKI_Suit.YoutubeService;
using KEYAKI_Suite.Repositry;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class KEYAKIYoutubePageViewModel : BindableBase
    {
        private YoutubeDataRepositry _youtubeModel;

        public ReactiveCommand<Item> YoutubeTapCommand { get; set; } = new ReactiveCommand<Item>();

        public ReactiveCollection<Item> YoutubeItems { get; set; }

        public KEYAKIYoutubePageViewModel(YoutubeDataRepositry youtubeModel)
        {
            _youtubeModel = youtubeModel;

            YoutubeItems = _youtubeModel.Youtube;

            _youtubeModel.GetData();

            YoutubeTapCommand
                .Where(o => YoutubeItems.Count != 0)
                .Where(snippet => snippet != null)
                .Subscribe(snippet => Device.OpenUri(new Uri("https://www.youtube.com/watch?v=" + snippet.id.videoId)));
        }
    }
}
