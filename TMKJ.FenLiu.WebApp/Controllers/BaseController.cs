using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TMKJ.FenLiu.Model;

namespace TMKJ.FenLiu.WebApp.Controllers
{
    public class BaseController : Controller
    {
        public TbUsers userinfo { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            userinfo = Session["TbUsers"] as TbUsers;
            if (userinfo == null)
            {
                Response.Redirect("/Home/Login");
            }
        }
    }
}
