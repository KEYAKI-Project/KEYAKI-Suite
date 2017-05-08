using Windows.UI.Xaml.Controls;
using KEYAKI_Suite.Native.UWP.ViewModels;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace KEYAKI_Suite.Native.UWP.Views
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class NewsPage : Page
    {
        public NewsPageViewModel NewsPageViewModel => this.DataContext as NewsPageViewModel;

        public NewsPage()
        {
            this.InitializeComponent();
        }
    }
}
