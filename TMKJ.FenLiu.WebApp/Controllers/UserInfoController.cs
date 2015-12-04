using TMKJ.FenLiu.Model;
using TMKJ.FenLiu.Enum;
using TMKJ.FenLiu.Model.SearchParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace TMKJ.FenLiu.WebApp.Controllers
{
    public class UserInfoController : BaseController
    {
        //
        // GET: /UserInfo/
        IBLL.IUserInfoService userInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取用户信息
        public ActionResult GetUserInfo()
        {
            var loginUser = Session["TbUsers"] as TbUsers;

            int pageIndex = int.Parse(Request["page"]);//当前页码.
            int pageSize = int.Parse(Request["rows"]);//当前每页显示记录数.
            int totalCount = 0;
            string name = Request["name"];//接收用户名
            string remark = Request["remark"];//接收备注信息
            UserInfoFilter userInfoFilter = new UserInfoFilter()//构建用户搜索过来的条件
            {
                UName = name,
                URmark = remark,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };
            var userInfoList = userInfoService.LoadEntities(C => true);//过滤用户的搜索条件
                                                                       //short deleteType = (short)DeleteEnumType.Normal;
                                                                       //  var userInfoList = userInfoService.LoadPageEntities<string>(pageIndex, pageSize, out totalCount, c => c.DelFlag == deleteType, c => c.Sort, true);//调用业务层.
            var temp = from u in userInfoList
                       where u.UsersId != loginUser.UsersId
                       select new { ID = u.UsersId, UName = u.UserName, UPwd = u.UserPwd,  Sort = u.DelFlag };
            return Json(new { rows = temp, total = userInfoFilter.TotalCount }, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region 删除用户信息.
        public ActionResult DeleteUserInfo()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<string> list = new List<string>();
            foreach (var id in strIds)
            {
                list.Add(id);
            }
            if (userInfoService.DeleteEntities(list))
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
            userInfoService.AddEntity(userInfo);
            return Content("ok");
        }
        #endregion

        #region 修改数据.
        public ActionResult EditUserInfo(TbUsers userInfo)
        {

            // userInfo.ModifiedOn = DateTime.Now;
            if (userInfoService.UpdateEntity(userInfo))
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
