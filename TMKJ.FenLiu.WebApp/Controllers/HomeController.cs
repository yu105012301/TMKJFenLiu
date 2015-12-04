using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TMKJ.FenLiu.BLL;
using TMKJ.FenLiu.IBLL;
using TMKJ.FenLiu.Model;

namespace TMKJ.FenLiu.WebApp.Controllers
{
    public class HomeController : Controller
    {
        IUserInfoService _IUserInfoService = new UserInfoService();
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TbUsers users)
        {
            TbUsers TbUsers = _IUserInfoService.UserLogin(users);
            if (TbUsers == null)
            {
                return JavaScript("alert('用户名或密码错误，登录失败！')");
            }
            Session["TbUsers"] = TbUsers;

            return JavaScript("window.location.href='/Index/AdminManage'");
        }


    }
}
