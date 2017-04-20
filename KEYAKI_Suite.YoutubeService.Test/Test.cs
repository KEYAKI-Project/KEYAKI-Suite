using NUnit.Framework;
using System.Threading.Tasks;
namespace KEYAKI_Suite.YoutubeService.Test
{
	[TestFixture()]
	public class Test
	{
		private YoutubeService youtubeservice => new YoutubeService();

		[Test()]
		public async void TestCase()
		{
			var hoge = await youtubeservice.GetYoutubeDataAsync();
			hoge.items.Length.IsNotNull();

		}
	}
}
