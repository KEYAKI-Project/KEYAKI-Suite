using Prism.Mvvm;
using System;
using System.Reactive.Linq;
using KEYAKI_Suite.UseCase;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class KEYAKINewsPageViewModel : BindableBase
    {
        private readonly KeyakiNewsListUseCase KeyakiNewsListUseCase;

        public ReactiveCollection<NewsData> NewsDatas { get; set; }

        public ReactiveCommand<NewsData> NewsTappedEvent { get; set; } = new ReactiveCommand<NewsData>();

        public KEYAKINewsPageViewModel(KeyakiNewsListUseCase keyakiNewsListUseCase)
        {
            // Receive Instance from DI
            KeyakiNewsListUseCase = keyakiNewsListUseCase;

            // Binding ReactiveCollection
            NewsDatas = KeyakiNewsListUseCase.NewsDatas;

            // Call Use Case Method
            KeyakiNewsListUseCase.FetchNewsDatasAsync();
            
            NewsTappedEvent
                .Where(o => NewsDatas.Count != 0)
                .Where(o => o != null)
                .Subscribe(o => Device.OpenUri(new Uri(o.Link)));
        }
    }
}
