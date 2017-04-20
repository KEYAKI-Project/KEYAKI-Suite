using System;
using System.Threading.Tasks;
using System.Net.Http;
using KEYAKI_Suit.YoutubeService;
using Newtonsoft.Json;
namespace KEYAKI_Suite.YoutubeService
{
	public class YoutubeService
	{
		public async Task<YoutubeData> GetYoutubeDataAsync()
		{
			var json = await GetYoutubeDataAPI();
			return Json2YoutubeData(json);
		}

		private YoutubeData Json2YoutubeData(string json)
		{
			return JsonConvert.DeserializeObject(json) as YoutubeData;
		}

		private async Task<string> GetYoutubeDataAPI()
		{
			using (var client = new HttpClient())
			{
				try
				{
					var Httpresult = await client.GetAsync("https://www.googleapis.com/youtube/v3/search?maxResults=20&part=snippet&channelId=UCmr9bYmymcBmQ1p2tLBRvwg&key=AIzaSyCy34PAhxHZixbSsVkpqWfpOs18dd90FgY");
					var json = await Httpresult.Content.ReadAsStringAsync();
					if (json == null) return "";
					return json;
				}
				catch (Exception)
				{
					return "";
				}
			}
		}
	}
}
