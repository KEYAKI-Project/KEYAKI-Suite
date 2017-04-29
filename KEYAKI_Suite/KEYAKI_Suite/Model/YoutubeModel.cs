
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;
using System.Linq;
using KEYAKI_Suit.YoutubeService;

namespace KEYAKI_Suite.Model
{
    public class YoutubeModel
	{
		public ReactiveCollection<Item> Youtube { get; set; } = new ReactiveCollection<Item>();


		public YoutubeModel()
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
