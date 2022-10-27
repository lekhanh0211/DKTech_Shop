using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    }

    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Posts
                        join pt in DbContext.PostTags
                        on p.Id equals pt.PostId
                        where pt.TagId == tag && p.Status
                        orderby p.CreatedDate descending
                        select p;

            totalRow = query.Count(); //trả ra số lượng bản ghi trong Db

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize); //check phân trang lấy từ bản ghi số bao nhiêu

            return query;
        }
    }
}
