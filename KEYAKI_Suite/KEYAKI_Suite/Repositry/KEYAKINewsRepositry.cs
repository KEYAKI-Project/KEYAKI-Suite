using Microsoft.Practices.ObjectBuilder2;
using Prism.Mvvm;
using Reactive.Bindings;

namespace KEYAKI_Suite.Repositry
{
    public class KEYAKINewsRepositry: BindableBase
    {
        public ReactiveCollection<NewsData> NewsDatas { get; set; } = new ReactiveCollection<NewsData>();

        public KEYAKINewsRepositry()
        {
            GetNewsDatas();
        }

        public async void GetNewsDatas()
        {
            var newservice = new KEYAKINewsService.KEYAKINewsService();
            var newss = await newservice.GetNewsData();
            newss.ForEach(news => NewsDatas.Add(news));

            
        }
    }
}
