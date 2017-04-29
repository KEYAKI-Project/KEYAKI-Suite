using System.Linq;
using NUnit.Framework;
using System.Threading.Tasks;
using KEYAKI_Suit.YoutubeService;

namespace KEYAKI_Suite.YoutubeService.Test
{
	[TestFixture()]
	public class Test
	{
		private YoutubeService youtubeservice => new YoutubeService();

	    [Test]
	    public async Task YoutubeのAPIからデータを取得できているか()
	    { 
	      (await youtubeservice.GetYoutubeDataAsync()).items.Length.IsNot(0);
	        var youtubedata = await youtubeservice.GetYoutubeDataAsync();
            youtubedata.IsNotNull();
            youtubedata.items.Length.IsNot(0);
	        var snippet = youtubedata.items.First().snippet;
            snippet.title.IsNot("");

	    }

		[Test()]
		public async Task Youtubeから取得したJsonを変換できているか()
		{
		    var json = await youtubeservice.AsDynamic().GetYoutubeDataAPI() as string;
            (youtubeservice.AsDynamic().Json2YoutubeData(json) as YoutubeData).IsNotNull();
        }

	    [Test]
	    public async Task 欅坂のYoutubeからHTMLを取得できているか()
	    {
	        ((await youtubeservice.AsDynamic().GetYoutubeDataAPI()) as string).IsNot("");
	        ((await youtubeservice.AsDynamic().GetYoutubeDataAPI()) as string).IsNotNull();
        }
    }
}
