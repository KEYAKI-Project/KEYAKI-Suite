using System.Linq;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Navigation;
using KEYAKI_Suite.Model;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace KEYAKI_Suite.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private KEYAKINewsModel _keyakiNewsModel;
        public ReactiveCollection<NewsData> NewsDatas { get; set; }
        public MainPageViewModel(KEYAKINewsModel keyakiNewsModel)
        {
            _keyakiNewsModel = keyakiNewsModel;
            _keyakiNewsModel.GetNewsDatas();
            NewsDatas = _keyakiNewsModel.NewsDatas;
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
