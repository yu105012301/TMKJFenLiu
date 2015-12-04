
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMKJ.FenLiu.Model.SearchParams
{
    /// <summary>
    /// 针对用户的搜索条件(注意:有可能还需要对其它的信息进行搜索，不管是搜索什么信息最后都要分页，所以把分页属性封装起来)
    /// </summary>
  public  class UserInfoFilter:BaseParam
    {
      public string UName { get; set; }
      public string URmark { get; set; }
    }
}
