using Shop.Data.Infrastructure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category> // Định nghĩa thêm các phương thức khác k có trong RepositoryBase
    {
        IEnumerable<Category> GetByAlias(string alias);
    }
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Category> GetByAlias(string alias)
        {
            return this.DbContext.Categories.Where(x => x.Alias == alias);
        }
    }
}
