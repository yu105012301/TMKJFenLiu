using TMKJ.FenLiu.DAL;
using TMKJ.FenLiu.IDAL;
using TMKJ.FenLiu.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMKJ.FenLiu.DALFactory
{
    /// <summary>
    /// DBSession
    /// </summary>
    public class DBSession : IDBSession
    {
        public DbContext Db
        {
            get { return DBContextFactory.CreateDbContext(); }
        }
        private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if (_UserInfoDal == null)
                {
                    _UserInfoDal = DALAbstractFactory.CreateUserInfoDal();
                }
                return _UserInfoDal;
            }
            set
            {
                _UserInfoDal = value;
            }
        }

        private ITbMajorDal _ITbMajorDal;
        public ITbMajorDal ITbMajorDal
        {
            get
            {
                if (_ITbMajorDal == null)
                {
                    _ITbMajorDal = DALAbstractFactory.CreateTbMajorDal();
                }
                return _ITbMajorDal;
            }
            set
            {
                _ITbMajorDal = value;
            }
        }

        /// <summary>
        /// 保存数据。
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return Db.SaveChanges() > 0;
        }
    }
}
