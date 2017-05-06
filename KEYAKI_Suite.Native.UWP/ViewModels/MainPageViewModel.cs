using Prism.Windows.Mvvm;
using Reactive.Bindings;

namespace KEYAKI_Suite.Native.UWP.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {
        public ReactiveProperty<string> Greeting { get; set; } = new ReactiveProperty<string>("Hello");
    }
}
