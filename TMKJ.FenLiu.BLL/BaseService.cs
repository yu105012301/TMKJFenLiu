using TMKJ.FenLiu.DALFactory;
using TMKJ.FenLiu.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMKJ.FenLiu.BLL
{
   public abstract class BaseService<T>where T:class,new()
    {
       public IDBSession DbSession
       {
         //  get { return new DBSession(); }//暂时先new.
           get { return DBSessionFactory.CreateDbSession(); }//完成DBSession创建.
       }
       public IDAL.IBaseDal<T> CurrentDal { get; set; }//获取当前数据操作类.

       public abstract void SetCurrentDal();
       public BaseService()
       {
           SetCurrentDal();//子类必须要实现该抽象方法。
       }
       /// <summary>
       /// 业务查询。
       /// </summary>
       /// <param name="whereLambda"></param>
       /// <returns></returns>
       public IQueryable<T> LoadEntities(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda)
       {
           return this.CurrentDal.LoadEntities(whereLambda);
       }
       /// <summary>
       /// 业务层查询分页
       /// </summary>
       /// <typeparam name="s"></typeparam>
       /// <param name="pageIndex"></param>
       /// <param name="pageSize"></param>
       /// <param name="totalCount"></param>
       /// <param name="whereLambda"></param>
       /// <param name="orderbyLambda"></param>
       /// <param name="isAsc"></param>
       /// <returns></returns>
       public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> whereLambda, System.Linq.Expressions.Expression<Func<T, s>> orderbyLambda, bool isAsc)
       {
           return this.CurrentDal.LoadPageEntities<s>(pageIndex,pageSize,out totalCount,whereLambda,orderbyLambda,isAsc);
       }
       /// <summary>
       /// 业务层删除
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
       public bool DeleteEntity(T entity)
       {
           this.CurrentDal.DeleteEntity(entity);
           return this.DbSession.SaveChanges();
       }
       /// <summary>
       /// 业务层更新
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
       public bool UpdateEntity(T entity)
       {
           this.CurrentDal.UpdateEntity(entity);
           return this.DbSession.SaveChanges();
       }
       /// <summary>
       /// 业务层添加
       /// </summary>
       /// <param name="entity"></param>
       /// <returns></returns>
       public T AddEntity(T entity)
       {
           this.CurrentDal.AddEntity(entity);
           this.DbSession.SaveChanges();
           return entity;
       }
    }
}
