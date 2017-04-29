using System.Linq;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using KEYAKI_Suite.Model;
using System;
using KEYAKI_Suite.Views;
using Reactive.Bindings;
using Xamarin.Forms;
using KEYAKI_Suit.YoutubeService;
using KEYAKI_Suite.KEYAKIBlogService;
using KEYAKI_Suite.Repositry;

namespace KEYAKI_Suite.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		private KEYAKINewsModel _keyakiNewsModel;
		private YoutubeModel _youtubeModel;
	    private KeyakiBlogDataRepositry BlogDataRepositry;

		public ReactiveCommand<NewsData> NewsTappedEvent { get; set; } = new ReactiveCommand<NewsData>();
		public ReactiveCommand<Item> YoutubeTapCommand { get; set; } = new ReactiveCommand<Item>();
	    public ReactiveCommand<KEYAKIBlogData> BlogItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIBlogData>();


		public ReactiveCollection<NewsData> NewsDatas { get; set; }
	    public ReactiveCollection<KEYAKIBlogData> KeyakiBlogDatas { get; set; }
		public ReactiveCollection<Item> Items { get; set; }
		public MainPageViewModel(KEYAKINewsModel keyakiNewsModel, YoutubeModel youtubeModel, KeyakiBlogDataRepositry blogDataRepositry)
		{
			_keyakiNewsModel = keyakiNewsModel;
			_youtubeModel = youtubeModel;
		    BlogDataRepositry = blogDataRepositry;

		    NewsDatas = _keyakiNewsModel.NewsDatas;
            
			Items = _youtubeModel.Youtube;

            
		    
            KeyakiBlogDatas = blogDataRepositry.KeyakiBlogDatas;

			YoutubeTapCommand
				.Where(o => Items.Count != 0)
				.Where(snippet => snippet != null)
				.Subscribe(snippet => Device.OpenUri(new Uri("https://www.youtube.com/watch?v=" + snippet.id.videoId)));

			NewsTappedEvent
				.Where(o => NewsDatas.Count != 0)
				.Where(o => o != null)
				.Subscribe(o => Device.OpenUri(new Uri(o.Link)));

		    BlogItemTapCommand
		        .Where(data => data != null)
		        .Subscribe(data => Device.OpenUri(new Uri("http://www.keyakizaka46.com/" + data.URL)));

        }


		public void OnNavigatedFrom(NavigationParameters parameters)
		{

		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{

		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}
	}
}
