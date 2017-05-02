using Prism.Mvvm;
using System;
using System.Reactive.Linq;
using KEYAKI_Suite.MatomeService;
using KEYAKI_Suite.Repositry;
using Reactive.Bindings;
using Xamarin.Forms;

namespace KEYAKI_Suite.ViewModels
{
    public class KEYAKIMatomePageViewModel : BindableBase
    {
        private KeyakiMatomeSiteDataRepostiry KeyakiMatomeSiteDataRepostiry;

        public ReactiveCommand<KEYAKIMatomeData> matomeItemTapCommand { get; set; } = new ReactiveCommand<KEYAKIMatomeData>();

        public ReactiveCollection<KEYAKIMatomeData> KeyakiMatomeDatas { get; set; }

        public KEYAKIMatomePageViewModel(KeyakiMatomeSiteDataRepostiry keyakiMatomeSiteDataRepostiry)
        {
            KeyakiMatomeSiteDataRepostiry = keyakiMatomeSiteDataRepostiry;

            KeyakiMatomeDatas = KeyakiMatomeSiteDataRepostiry.MatomeDatas;

            KeyakiMatomeSiteDataRepostiry.getData();

            matomeItemTapCommand
                .Where(data => data != null)
                .Subscribe(data => Device.OpenUri(new Uri(data.PostURL)));
        }
    }
}
