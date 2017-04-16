using System.Linq;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using KEYAKI_Suite.Model;
using  System;
using KEYAKI_Suite.Views;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private KEYAKINewsModel _keyakiNewsModel;
        private readonly INavigationService _navigationService;

        public ReactiveCommand<NewsData> NewsTappedEvent { get; set; } = new ReactiveCommand<NewsData>();
        public ReactiveCommand NavigateSettingPageCommand { get; set; } = new ReactiveCommand();
        public ReactiveCollection<NewsData> NewsDatas { get; set; }
        public MainPageViewModel(KEYAKINewsModel keyakiNewsModel, INavigationService navigationService)
        {
            _keyakiNewsModel = keyakiNewsModel;
            _navigationService = navigationService;
            NewsDatas = _keyakiNewsModel.NewsDatas;

            NavigateSettingPageCommand.Subscribe(o =>
            {
                navigationService.NavigateAsync(nameof(SettingPage));
            });

            NewsTappedEvent
                .Where(o => NewsDatas.Count != 0)
                .Where(o => o != null)
                .Subscribe(o => Device.OpenUri(new Uri(o.Link)));
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
