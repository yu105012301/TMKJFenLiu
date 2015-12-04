using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.HeiMaOA.SpringNetDemo
{
   public class UserInfoService:IUserInfoService
    {
       public string Name { get; set; }
       public Person Person { get; set; }
        public string ShowMsg()
        {
            return "Hello World:"+Name+"年龄是:"+Person.Age;
        }
    }
}
