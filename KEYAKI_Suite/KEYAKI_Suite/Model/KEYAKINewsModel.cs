using Microsoft.Practices.ObjectBuilder2;
using Prism.Mvvm;
using Reactive.Bindings;


namespace KEYAKI_Suite.Model
{
    public class KEYAKINewsModel: BindableBase
    {
        public ReactiveCollection<NewsData> NewsDatas { get; set; } = new ReactiveCollection<NewsData>();

        public KEYAKINewsModel()
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
