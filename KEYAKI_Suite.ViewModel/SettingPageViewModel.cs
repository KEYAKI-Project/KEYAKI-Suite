using Prism.Mvvm;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class SettingPageViewModel : BindableBase
    {
        public ReactiveProperty<string> CopylightURL { get; set; }

        public SettingPageViewModel()
        {
            CopylightURL = new ReactiveProperty<string>(
                "https://raw.githubusercontent.com/KEYAKI-Project/KEYAKI-Suite/master/KEYAKI_Suite.License/License.html");
        }
    }
}
