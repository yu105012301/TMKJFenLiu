using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMKJ.FenLiu.Model;
using TMKJ.FenLiu.Common;

namespace TMKJ.FenLiu.WebApp.Controllers
{
    public class TbMajorController : BaseController
    {
        IBLL.ITbMajorService tbMajorService { get; set; }
        //
        // GET: /Manage/

        /// <summary>
        ///     显示所有的专业
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.UserInfo = userinfo;
            return View();
        }

        public ActionResult TbMajorList()
        {
            ViewBag.UserInfo = userinfo;
            int pageIndex = int.Parse(Request["page"]);//当前页码.
            int pageSize = int.Parse(Request["rows"]);//当前每页显示记录数.
            int totalCount = 0;
            var majorinfo = tbMajorService.LoadPageEntities<int>(pageIndex, pageSize, out totalCount, c => true, c => c.MajorNumber, true);
            var temp = from u in majorinfo
                       select new { MajorId = u.MajorId, MajorNumber = u.MajorNumber, MajorName = u.MajorName, MajorMark = u.MajorMark, MajorCount = u.MajorCount, DelFlag = u.DelFlag, CreateTime = u.CreateTime, ModifyTime = u.ModifyTime };
            return Json(new { rows = temp, total = totalCount }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditMajorInfo(TbMajor entity)
        {
            entity.ModifyTime = DateTime.Now;
            if (tbMajorService.UpdateEntity(entity))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        [HttpPost]
        public ActionResult DeleteTbMajorInfo()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<string> list = new List<string>();
            foreach (var majorid in strIds)
            {
                list.Add(majorid);
            }
            if (tbMajorService.DeleteEntities(list) == 1)
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }

        #region 增加
        [HttpPost]
        public ActionResult AddMajorInfo(TbMajor entity)
        {
            entity.MajorId = Guid.NewGuid().ToComb();
            entity.ModifyTime = DateTime.Now;
            entity.CreateTime = DateTime.Now;
            tbMajorService.AddEntity(entity);
            return Content("ok");
        } 
        #endregion
    }
}
