using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using KEYAKI_Suite.Model;
using Microsoft.Practices.ObjectBuilder2;
using Reactive.Bindings;

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
