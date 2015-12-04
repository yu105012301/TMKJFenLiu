using TMKJ.FenLiu.Model;
using TMKJ.FenLiu.Model.SearchParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMKJ.FenLiu.IBLL
{
    public interface IUserInfoService : IBaseService<TbUsers>
    {
        /// <summary>
        /// 批量删除用户信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool DeleteEntities(List<string> list);
        TbUsers UserLogin(TbUsers users);
    }
}
