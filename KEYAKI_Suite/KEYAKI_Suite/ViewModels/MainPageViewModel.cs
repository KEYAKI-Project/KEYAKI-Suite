using System.Linq;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using KEYAKI_Suite.Model;
using System;
using KEYAKI_Suite.Views;
using Reactive.Bindings;
using Xamarin.Forms;
using KEYAKI_Suite.define;

namespace KEYAKI_Suite.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
		private KEYAKINewsModel _keyakiNewsModel;
		private YoutubeModel _youtubeModel;
		private readonly INavigationService _navigationService;

		public ReactiveCommand<NewsData> NewsTappedEvent { get; set; } = new ReactiveCommand<NewsData>();
		public ReactiveCommand<Item> YoutubeTapCommand { get; set; } = new ReactiveCommand<Item>();
		public ReactiveCommand NavigateSettingPageCommand { get; set; } = new ReactiveCommand();
		public ReactiveCollection<NewsData> NewsDatas { get; set; }
		public ReactiveCollection<Item> Snippets { get; set; }
		public MainPageViewModel(KEYAKINewsModel keyakiNewsModel, INavigationService navigationService, YoutubeModel youtubeModel)
		{
			_keyakiNewsModel = keyakiNewsModel;
			_navigationService = navigationService;
			_youtubeModel = youtubeModel;

			NewsDatas = _keyakiNewsModel.NewsDatas;
			Snippets = _youtubeModel.YoutubeCollection;

			NavigateSettingPageCommand.Subscribe(o =>
			{
				navigationService.NavigateAsync(nameof(SettingPage));
			});

			YoutubeTapCommand
				.Where(o => Snippets.Count != 0)
				.Where(snippet => snippet != null)
				.Subscribe(snippet => Device.OpenUri(new Uri("https://www.youtube.com/watch?v=" + snippet.id.videoId)));

			NewsTappedEvent
				.Where(o => NewsDatas.Count != 0)
				.Where(o => o != null)
				.Subscribe(o => Device.OpenUri(new Uri(o.Link)));
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
