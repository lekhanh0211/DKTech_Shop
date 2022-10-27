using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Infrastructure
{
     public interface IDbFactory : IDisposable // triển khai từ interface IDisposable
    {
        //Chỉ cần 1 phương thức để init thằng DbContext
        Shop_DbContext Init();
    }
}
