using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using Reactive.Bindings;
using Xamarin.Forms;
using KEYAKI_Suit.YoutubeService;
using KEYAKI_Suite.KEYAKIBlogService;
using KEYAKI_Suite.MatomeService;
using KEYAKI_Suite.Repositry;
using KEYAKI_Suite.UseCase;

namespace KEYAKI_Suite.ViewModels
{
	public class MainPageViewModel : BindableBase, INavigationAware
	{
	    private readonly KeyakiNewsListUseCase KeyakiNewsListUseCase;
		private YoutubeDataRepositry _youtubeModel;
	    private KeyakiMatomeSiteDataRepostiry KeyakiMatomeSiteDataRepostiry;

		public ReactiveCommand<NewsData> NewsTappedEvent { get; set; } = new ReactiveCommand<NewsData>();
		public ReactiveCommand<Item> YoutubeTapCommand { get; set; } = new ReactiveCommand<Item>();
	    public ReactiveCommand<KEYAKIBlogData> BlogItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIBlogData>();
        public ReactiveCommand<KEYAKIMatomeData> matomeItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIMatomeData>();

        public ReactiveCollection<NewsData> NewsDatas { get; set; }
	    public ReactiveCollection<KEYAKIBlogData> KeyakiBlogDatas { get; set; }
		public ReactiveCollection<Item> Items { get; set; }
	    public ReactiveCollection<KEYAKIMatomeData> KeyakiMatomeDatas { get; set; }
        public MainPageViewModel(YoutubeDataRepositry youtubeModel, KeyakiBlogDataRepositry blogDataRepositry, KeyakiMatomeSiteDataRepostiry keyakiMatomeSiteDataRepostiry, KeyakiNewsListUseCase keyakiNewsListUseCase)
		{
			_youtubeModel = youtubeModel;
		    KeyakiMatomeSiteDataRepostiry = keyakiMatomeSiteDataRepostiry;
		    KeyakiNewsListUseCase = keyakiNewsListUseCase;

		    NewsDatas = KeyakiNewsListUseCase.NewsDatas;
            
			Items = _youtubeModel.Youtube;

		    KeyakiMatomeDatas = KeyakiMatomeSiteDataRepostiry.MatomeDatas;
            
		    
            KeyakiMatomeSiteDataRepostiry.getData();
            KeyakiNewsListUseCase.FetchNewsDatasAsync();


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

		    matomeItemTapCommand
		        .Where(data => data != null)
		        .Subscribe(data => Device.OpenUri(new Uri(data.PostURL)));
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
