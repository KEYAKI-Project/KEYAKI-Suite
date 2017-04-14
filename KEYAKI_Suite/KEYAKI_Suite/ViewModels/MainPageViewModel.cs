using System.Linq;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using KEYAKI_Suite.Model;
using  System;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private KEYAKINewsModel _keyakiNewsModel;

        public ReactiveProperty<NewsData> TappedNewsData { get; set; } = new ReactiveProperty<NewsData>();

        public ReactiveCommand NewsTappedEvent { get; set; } = new ReactiveCommand();

        public ReactiveCollection<NewsData> NewsDatas { get; set; }
        public MainPageViewModel(KEYAKINewsModel keyakiNewsModel)
        {
            _keyakiNewsModel = keyakiNewsModel;
            _keyakiNewsModel.GetNewsDatas();
            NewsDatas = _keyakiNewsModel.NewsDatas;
            
            NewsTappedEvent
                .Where(o => NewsDatas.Count != 0)
                .Subscribe(o => Device.OpenUri(new Uri(TappedNewsData.Value.Link)));
        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
