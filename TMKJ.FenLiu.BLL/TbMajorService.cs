using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMKJ.FenLiu.IBLL;
using TMKJ.FenLiu.Model;

namespace TMKJ.FenLiu.BLL
{
    public class TbMajorService : BaseService<TbMajor>, ITbMajorService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.ITbMajorDal;
        }

        #region 批量删除
        /// <summary>
        ///     批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int DeleteEntities(List<string> list)
        {
            var majorInfoList = this.DbSession.ITbMajorDal.LoadEntities(u => list.Contains(u.MajorId));
            if (true)//查询关联的志愿表，如果志愿表里没有这一条志愿则可以删除，并返回1
            {
                if (majorInfoList != null)
                {
                    foreach (var majorInfo in majorInfoList)
                    {
                        this.DbSession.ITbMajorDal.DeleteEntity(majorInfo);//将删除的数据添加到EF上下文中，并且添加了删除标记.
                    }
                }
                this.DbSession.SaveChanges();
                return 1;
            }
            //如果志愿表里有这一条数据则不能删除，返回2
            //return 2;
        } 
        #endregion
    }
}
