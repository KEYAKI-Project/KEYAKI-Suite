using KEYAKI_Suite.UseCase;
using Prism.Windows.Mvvm;
using Reactive.Bindings;

namespace KEYAKI_Suite.Native.UWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly KeyakiNewsListUseCase _keyakiNewsListUseCase;

        public ReactiveCollection<NewsData> NewsDatas { get; set; }

        public MainPageViewModel(KeyakiNewsListUseCase keyakiNewsListUseCase)
        {
            _keyakiNewsListUseCase = keyakiNewsListUseCase;

            NewsDatas = _keyakiNewsListUseCase.NewsDatas;

            _keyakiNewsListUseCase.FetchNewsDatasAsync();
        }
    }
}
