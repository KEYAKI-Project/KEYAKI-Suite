using Prism.Mvvm;
using System;
using System.Reactive.Linq;
using KEYAKI_Suite.MatomeService;

using KEYAKI_Suite.Repositry;
using KEYAKI_Suite.UseCase;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class KeyakiMatomePageViewModel : BindableBase
    {
        private readonly KeyakiMatomeListUseCase KeyakiMatomeListUseCase;

        public ReactiveCommand<KEYAKIMatomeData> matomeItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIMatomeData>();

        public ReactiveCollection<KEYAKIMatomeData> KeyakiMatomeDatas { get; set; }

        public KEYAKIMatomePageViewModel(KeyakiMatomeListUseCase keyakiMatomeListUseCase)
        {
            KeyakiMatomeListUseCase = keyakiMatomeListUseCase;

            KeyakiMatomeDatas = KeyakiMatomeListUseCase.MatomeDatas;

            KeyakiMatomeListUseCase.FetchMatomeData();

            matomeItemTapCommand
                .Where(data => data != null)
                .Subscribe(data => Device.OpenUri(new Uri(data.PostURL)));
        }
    }
}
