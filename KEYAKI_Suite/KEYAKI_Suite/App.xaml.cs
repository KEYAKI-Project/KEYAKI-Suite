﻿using System;
using System.Reflection;
using KEYAKI_Suite.ViewModel;
using KEYAKI_Suite.ViewModels;
using Prism.Unity;
using KEYAKI_Suite.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace KEYAKI_Suite
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(ViewTypeToViewModelTypeResolver.Resolve);
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SettingPage>();
            Container.RegisterTypeForNavigation<KEYAKINewsPage>();
            Container.RegisterTypeForNavigation<KEYAKIYoutubePage>();
            Container.RegisterTypeForNavigation<KEYAKIBlogPage>();
            Container.RegisterTypeForNavigation<KEYAKIMatomePage>();
        }
    }
}
