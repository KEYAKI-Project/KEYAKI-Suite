using KEYAKI_Suit.YoutubeService;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

namespace KEYAKI_Suite.Repositry
{
    public class YoutubeDataRepositry
	{
		public ReactiveCollection<Item> Youtube { get; set; } = new ReactiveCollection<Item>();


		public YoutubeDataRepositry()
		{
			GetData();
		}

		public async void GetData()
		{
		    var newservice = new YoutubeService.YoutubeService();
		    var newss = await newservice.GetYoutubeDataAsync();
		    newss.items.ForEach(item => Youtube.Add(item));
        }
	}
}
