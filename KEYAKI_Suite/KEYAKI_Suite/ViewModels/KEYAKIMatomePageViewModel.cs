using Prism.Mvvm;
using System;
using System.Reactive.Linq;
using KEYAKI_Suite.MatomeService;
using KEYAKI_Suite.UseCase;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class KEYAKIMatomePageViewModel : BindableBase
    {
        private readonly KeyakisakaMatomeListUseCase KeyakisakaMatomeListUseCase;

        public ReactiveCommand<KEYAKIMatomeData> matomeItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIMatomeData>();

        public ReactiveCollection<KEYAKIMatomeData> KeyakiMatomeDatas { get; set; }

        public KEYAKIMatomePageViewModel(KeyakisakaMatomeListUseCase keyakisakaMatomeListUseCase)
        {
            KeyakisakaMatomeListUseCase = keyakisakaMatomeListUseCase;


            KeyakiMatomeDatas = KeyakisakaMatomeListUseCase.MatomeDatas;

            KeyakisakaMatomeListUseCase.FetchMatomeData();

            matomeItemTapCommand
                .Where(data => data != null)
                .Subscribe(data => Device.OpenUri(new Uri(data.PostURL)));
        }
    }
}
