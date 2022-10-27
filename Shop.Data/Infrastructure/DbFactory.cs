using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory//kế thừ từ 1 i và 1 abstract thì đươc nhưng 2 abstrac thì k được
    {
        Shop_DbContext dbContext;
        public Shop_DbContext Init() // triển khai lớp DbFactory
        {
            return dbContext ?? (dbContext = new Shop_DbContext()); //Init kiểm tra nếu null thì ta khởi tạo 1 cái 
        }
        protected override void DisposeCore()
        {
            if (dbContext != null) //khác null thì ta sẽ dispose nó
                dbContext.Dispose();
        }
    }
}
