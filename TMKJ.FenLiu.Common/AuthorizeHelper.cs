using System;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;

namespace TMKJ.FenLiu.Common
{
    /// <summary>
    /// 授权认证帮助类
    /// </summary>
    public class AuthorizeHelper<TUserInfo> where TUserInfo : class ,new()
    {
        //用户ticket名
        // ReSharper disable once StaticFieldInGenericType
        private static readonly string _ticketname = "__userticket";

        /// <summary>
        /// 将登录的用户信息存到cookie中（默认保存60分钟）
        /// </summary>
        /// <param name="userInfo">将用户Id、用户角色、用户姓名、选择的语言种类 保存起来</param>
        public static void SaveToCookie(object userInfo)
        {
            SaveToCookie(userInfo, 60);
        }

        /// <summary>
        /// 将登录的用户信息存到cookie中
        /// </summary>
        /// <param name="userInfo">将用户Id、用户角色、用户姓名、选择的语言种类 保存起来</param>
        /// <param name="minutes">cookie有效时长，单位分钟</param>
        public static void SaveToCookie(object userInfo, int minutes)
        {
            string userData = JsonConvert.SerializeObject(userInfo);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,                              //token版本
                _ticketname,
                DateTime.Now,
                DateTime.Now.AddDays(1.0),      //token过期时间
                true,
                userData);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            cookie.HttpOnly = true;
            cookie.Path = "/";
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Expires = DateTime.Now.AddMinutes(minutes);         //cookie过期时间
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 从cookie中获取存储的用户信息
        /// </summary>
        /// <typeparam name="TUserInfo"></typeparam>
        /// <returns></returns>
        public static TUserInfo GetUserDataFromCookie()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            //加密的授权编码
            string authCode = cookie != null && cookie.Value != null
                ? cookie.Value
                : HttpContext.Current.Request.Form[FormsAuthentication.FormsCookieName];
            if (!string.IsNullOrEmpty(authCode))
            {
                var ticket = FormsAuthentication.Decrypt(authCode);
                if (ticket != null)
                {
                    var userData = JsonConvert.DeserializeObject<TUserInfo>(ticket.UserData);
                    return userData;
                }
            }
            return default(TUserInfo);
        }

        /// <summary>
        /// 当前登录用户实体
        /// （当前需要登录的页面使用，从Session中获取用户信息，Session过期时，只能获取到用户Id和角色信息）
        /// </summary>
        public static TUserInfo CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["user"] != null)
                {
                    return HttpContext.Current.Session["user"] as TUserInfo;
                }
                return GetUserDataFromCookie();
            }
        }
    }
}
