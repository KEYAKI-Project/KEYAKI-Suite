using KEYAKI_Suite.MatomeService;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

namespace KEYAKI_Suite.UseCase
{
    public class KeyakiMatomeListUseCase
    {
        private readonly KEYAKIMatomeService KeyakiMatomeService;

        public ReactiveCollection<KEYAKIMatomeData> MatomeDatas { get; set; } = new ReactiveCollection<KEYAKIMatomeData>();

        public KeyakiMatomeListUseCase(KEYAKIMatomeService keyakiMatomeService)
        {
            KeyakiMatomeService = keyakiMatomeService;
        }

        public async void FetchMatomeData()
        {
            var keyakiMatomeDatas = await KeyakiMatomeService.GetMatomeData();
            keyakiMatomeDatas.ForEach(data => MatomeDatas.Add(data));
        }
    }
}
