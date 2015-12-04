using TMKJ.FenLiu.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TMKJ.FenLiu.DAL
{
   public class DBContextFactory
    {
       /// <summary>
       /// 保证在一次请求过程中只创建一次EF上下文实例.
       /// </summary>
       /// <returns></returns>
       public static DbContext CreateDbContext()
       {
           DbContext dbContext = (DbContext)CallContext.GetData("dbContext");
           if (dbContext == null)
           {
               dbContext = new ShuntContext();
               CallContext.SetData("dbContext", dbContext);
           }
           return dbContext;
       }
    }
}
