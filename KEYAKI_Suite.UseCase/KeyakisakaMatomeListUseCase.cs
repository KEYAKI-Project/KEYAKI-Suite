using KEYAKI_Suite.MatomeService;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

namespace KEYAKI_Suite.UseCase
{
    public class KeyakisakaMatomeListUseCase
    {
        private readonly KEYAKIMatomeService _keyakiMatomeService;

        public ReactiveCollection<KEYAKIMatomeData> MatomeDatas { get; set; } = new ReactiveCollection<KEYAKIMatomeData>();

        public KeyakisakaMatomeListUseCase(KEYAKIMatomeService keyakiMatomeService)
        {
            _keyakiMatomeService = keyakiMatomeService;
        }

        public async void FetchMatomeData()
        {
            var keyakiMatomeDatas = await _keyakiMatomeService.GetMatomeData();
            keyakiMatomeDatas.ForEach(data => MatomeDatas.Add(data));
        }
    }
}
