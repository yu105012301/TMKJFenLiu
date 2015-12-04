using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMKJ.FenLiu.Model;

namespace TMKJ.FenLiu.IBLL
{
    public interface ITbMajorService : IBaseService<TbMajor>
    {
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        int DeleteEntities(List<string> list);
    }
}
