using TMKJ.FenLiu.IBLL;
using TMKJ.FenLiu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMKJ.FenLiu.Common;

namespace TMKJ.FenLiu.BLL
{
    public class UserInfoService : BaseService<TbUsers>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            CurrentDal = this.DbSession.UserInfoDal;
        }
        //public void SetUserRole()
        //{

        //    thin.UserInfoDal.AddEntity(UserInfo userInfo);
        //    this.DbSessions.DbSessio.RoleInfoDal.AddEntity(RoleInfo roleInfo);
        //    this.DbSession.SaveChanges();
        //}

        //public Func<UserInfo, bool> aa;
        //public bool bb(UserInfo u)
        //{
        //    if (u.ID == 1)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public TbUsers UserLogin(TbUsers users)
        {
            if (users == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(users.UserCode) || string.IsNullOrEmpty(users.UserPwd))
            {
                return null;
            }
            var temp = CurrentDal.LoadEntities(c => c.UserCode == users.UserCode).FirstOrDefault();
            if (temp != null)
            {
                IEncrypt encrypt = new Md5Encryption();
                if (temp.UserPwd != encrypt.EncryptData(users.UserPwd))
                {
                    return null;
                }
                AuthorizeHelper<TbUsers>.SaveToCookie(
                    new
                    {
                        UsersId = temp.UsersId,
                        UserCode = temp.UserCode,
                        UserName = temp.UserName
                    }, 60);
            }
            return temp;
        }

        #region 批量删除用户数据
        public bool DeleteEntities(List<string> list)//1,3,4
        {
            //UserInfo u = new UserInfo();
            //s => aa(s)aa = bb;
            var userInfoList = this.DbSession.UserInfoDal.LoadEntities(u => list.Contains(u.UsersId));
            if (userInfoList != null)
            {
                foreach (var userInfo in userInfoList)
                {
                    this.DbSession.UserInfoDal.DeleteEntity(userInfo);//将删除的数据添加到EF上下文中，并且添加了删除标记.
                }
            }
            return this.DbSession.SaveChanges();//最后调用DBSession中的SaveChanges方法将数据一次性提交回数据库.
        }
        #endregion

    }
}
