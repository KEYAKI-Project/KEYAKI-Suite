using KEYAKI_Suite.MatomeService;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

namespace KEYAKI_Suite.UseCase
{
    public class KeyakisakaMatomeListUseCase
    {
        private readonly KEYAKIMatomeService KeyakiMatomeService;

        public ReactiveCollection<KEYAKIMatomeData> MatomeDatas { get; set; } = new ReactiveCollection<KEYAKIMatomeData>();

        public KeyakisakaMatomeListUseCase(KEYAKIMatomeService keyakiMatomeService)
        {
            KeyakiMatomeService = keyakiMatomeService;
        }

        public async void Fetch()
        {
            var keyakiMatomeDatas = await KeyakiMatomeService.GetMatomeData();
            keyakiMatomeDatas.ForEach(data => MatomeDatas.Add(data));
        }
    }
}
