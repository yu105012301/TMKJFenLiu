using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMKJ.FenLiu.IDAL
{
   public interface IDBSession
    {
       IUserInfoDal UserInfoDal { get; set; }
       ITbMajorDal ITbMajorDal { get; set; }
       bool SaveChanges();
    }
}
