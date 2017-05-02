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
		
	    private KeyakiMatomeSiteDataRepostiry KeyakiMatomeSiteDataRepostiry;
        
		
	    public ReactiveCommand<KEYAKIBlogData> BlogItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIBlogData>();
        public ReactiveCommand<KEYAKIMatomeData> matomeItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIMatomeData>();

        public ReactiveCollection<NewsData> NewsDatas { get; set; }
	    public ReactiveCollection<KEYAKIBlogData> KeyakiBlogDatas { get; set; }
		
	    public ReactiveCollection<KEYAKIMatomeData> KeyakiMatomeDatas { get; set; }
        public MainPageViewModel(YoutubeDataRepositry youtubeModel, KeyakiBlogDataRepositry blogDataRepositry, KeyakiMatomeSiteDataRepostiry keyakiMatomeSiteDataRepostiry, KeyakiNewsListUseCase keyakiNewsListUseCase)
		{
		    KeyakiMatomeSiteDataRepostiry = keyakiMatomeSiteDataRepostiry;
            

		    KeyakiMatomeDatas = KeyakiMatomeSiteDataRepostiry.MatomeDatas;
            
		    
            KeyakiMatomeSiteDataRepostiry.getData();


            KeyakiBlogDatas = blogDataRepositry.KeyakiBlogDatas;

			
            
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
