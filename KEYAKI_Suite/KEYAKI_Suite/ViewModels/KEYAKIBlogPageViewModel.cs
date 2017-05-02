using Prism.Mvvm;
using System;
using System.Reactive.Linq;
using KEYAKI_Suite.KEYAKIBlogService;
using KEYAKI_Suite.UseCase;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class KEYAKIBlogPageViewModel : BindableBase
    {
        private readonly KeyakiBlogListUseCase BlogListUseCase;
        public ReactiveCommand<KEYAKIBlogData> BlogItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIBlogData>();

        public ReactiveCollection<KEYAKIBlogData> KeyakiBlogDatas { get; set; }

        public KEYAKIBlogPageViewModel(KeyakiBlogListUseCase blogListUseCase)
        {
            BlogListUseCase = blogListUseCase;

            KeyakiBlogDatas = BlogListUseCase.KeyakiBlogDatas;

            BlogListUseCase.FetchBlogData();

            BlogItemTapCommand
                .Where(data => data != null)
                .Subscribe(data => Device.OpenUri(new Uri("http://www.keyakizaka46.com/" + data.URL)));
        }
    }
}
