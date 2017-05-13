using System.Collections.Generic;
using System.Threading.Tasks;

namespace KEYAKI_Suite.KEYAKIBlogService
{
    public interface IKeyakiBlogService
    {
        Task<List<KEYAKIBlogData>> GetBlogData(int pageNumber = 0, int ArticleNumber = 25);
    }
}