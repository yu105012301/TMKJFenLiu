using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TMKJ.FenLiu.BLL;
using TMKJ.FenLiu.IBLL;
using TMKJ.FenLiu.Model;
using TMKJ.FenLiu.Common;

namespace TMKJ.FenLiu.WebApp.Controllers
{
    
    public class IndexController : BaseController
    {
        IUserInfoService _TbUsersService = new UserInfoService();
        // GET: Index
        public ActionResult AdminManage()
        {
            ViewData.Model = userinfo;
            return View();
        }

        #region 获得所有教师列表
        /// <summary>
        ///     教师管理
        /// </summary>
        /// <returns></returns>
        public ActionResult TeacherManage()
        {
            var temp = _TbUsersService.LoadEntities(c => true);
            ViewData.Model = userinfo;
            ViewBag.TeacherList = temp;
            return View();
        } 
        #endregion

        #region 获得教师信息
        /// <summary>
        ///     获得教师信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTeacherInfo()
        {

            int pageIndex = int.Parse(Request["page"]);
            int pageSize = int.Parse(Request["rows"]);
            int totalCount;
            var teacherinfo = _TbUsersService.LoadPageEntities<string>(pageIndex, pageSize, out totalCount, c => true, c => c.UsersId, true);
            var temp = from u in teacherinfo
                       where u.UsersId != userinfo.UsersId
                       select new { UserCode = u.UserCode, UsersId = u.UsersId, UserName = u.UserName, UserPwd = u.UserPwd, SysRole = u.SysRole, CreateTime = u.CreateTime, ModifyTime = u.ModifyTime };
            totalCount = temp.Count();
            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region 删除信息
        public ActionResult DeleteUserInfo()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<string> list = new List<string>();
            foreach (var userid in strIds)
            {
                list.Add(userid);
            }
            if (_TbUsersService.DeleteEntities(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

        #region 添加用户信息
        public ActionResult AddUserInfo(TbUsers userInfo)
        {
            userInfo.UsersId = Guid.NewGuid().ToComb();
            userInfo.ModifyTime = DateTime.Now;
            userInfo.CreateTime = DateTime.Now;
            _TbUsersService.AddEntity(userInfo);
            return Content("ok");
        }
        #endregion

        #region 修改数据.
        public ActionResult EditUserInfo(TbUsers userInfo)
        {
            userInfo.ModifyTime = DateTime.Now;

            // userInfo.ModifiedOn = DateTime.Now;
            if (_TbUsersService.UpdateEntity(userInfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }

        }
        #endregion
    }
}

