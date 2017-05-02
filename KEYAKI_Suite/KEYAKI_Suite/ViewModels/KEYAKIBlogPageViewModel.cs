using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using KEYAKI_Suite.KEYAKIBlogService;
using KEYAKI_Suite.Repositry;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class KEYAKIBlogPageViewModel : BindableBase
    {
        private readonly KeyakiBlogDataRepositry BlogDataRepositry;
        public ReactiveCommand<KEYAKIBlogData> BlogItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIBlogData>();

        public ReactiveCollection<KEYAKIBlogData> KeyakiBlogDatas { get; set; }

        public KEYAKIBlogPageViewModel(KeyakiBlogDataRepositry blogDataRepositry)
        {
            BlogDataRepositry = blogDataRepositry;
            KeyakiBlogDatas = blogDataRepositry.KeyakiBlogDatas;

            BlogItemTapCommand
                .Where(data => data != null)
                .Subscribe(data => Device.OpenUri(new Uri("http://www.keyakizaka46.com/" + data.URL)));
        }
    }
}
