
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;
using KEYAKI_Suit.YoutubeService;
using System.Linq;

namespace KEYAKI_Suite.Model
{
	public class YoutubeModel
	{
		public ReactiveCollection<Item> Youtube { get; set; } = new ReactiveCollection<Item>();

		public YoutubeService.YoutubeService Youtubeservice { get; set; } = new YoutubeService.YoutubeService();

		public YoutubeModel()
		{
			GetData();
		}

		private async void GetData()
		{
			var youtubecollection = await Youtubeservice.GetYoutubeDataAsync();
			youtubecollection.items.Where(item => item != null).ForEach(item => Youtube.Add(item));
		}

	}
}
