using System.Collections.Generic;
using System.Threading.Tasks;
using KEYAKI_Suite.Entity;

namespace KEYAKI_Suite.KEYAKIBlogService
{
    public interface IKeyakiBlogService
    {
        Task<IEnumerable<Entity.KEYAKIBlogData>> GetBlogData(int pageNumber = 0, int ArticleNumber = 25);
    }
}