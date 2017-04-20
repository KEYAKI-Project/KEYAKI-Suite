
using KEYAKI_Suite.define;
using Microsoft.Practices.ObjectBuilder2;
using Newtonsoft.Json;
using Reactive.Bindings;
using HttpClient = System.Net.Http.HttpClient;

namespace KEYAKI_Suite.Model
{
	public class YoutubeModel
	{
		public ReactiveCollection<Item> YoutubeCollection { get; set; } = new ReactiveCollection<Item>();

		public YoutubeModel()
		{
			GetData();
		}

		private async void GetData()
		{
			using (var client = new HttpClient())
			{
				var result = await client.GetAsync(
					"https://www.googleapis.com/youtube/v3/search?maxResults=20&part=snippet&channelId=UCmr9bYmymcBmQ1p2tLBRvwg&key=AIzaSyCy34PAhxHZixbSsVkpqWfpOs18dd90FgY");
				var json = await result.Content.ReadAsStringAsync();
				var youtubedata = JsonConvert.DeserializeObject<YoutubeData>(json);
				youtubedata.items.ForEach(item =>
				{
					YoutubeCollection.Add(item);
				});
			}
		}
	}

	public class YoutubeInfo
	{
		public string Title { get; set; }
		public string Detail { get; set; }
		public string ImagePath { get; set; }
	}
}
