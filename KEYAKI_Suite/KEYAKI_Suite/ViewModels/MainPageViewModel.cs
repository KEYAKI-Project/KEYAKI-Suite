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
        public ReactiveCollection<NewsData> NewsDatas { get; set; } = new ReactiveCollection<NewsData>();
        public MainPageViewModel()
        {
            var keyakiNewsModel = new KEYAKINewsModel();
            keyakiNewsModel.GetNewsDatas().ForEach(data => NewsDatas.Add(data));
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
