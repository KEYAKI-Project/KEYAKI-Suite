using KEYAKI_Suite.MatomeService;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

namespace KEYAKI_Suite.Repositry
{
    public class KeyakiMatomeSiteDataRepostiry
    {
        public ReactiveCollection<KEYAKIMatomeData> MatomeDatas { get; set; } = new ReactiveCollection<KEYAKIMatomeData>();



        public void KeyakiBlogDataRepositry()
        {
          getData();   
        }

        public async void getData()
        {
            var keyakiMatomeService = new KEYAKIMatomeService();
            var matomeData = await keyakiMatomeService.GetMatomeData();
            matomeData?.ForEach(data => MatomeDatas.Add(data));
        }

    }
}
