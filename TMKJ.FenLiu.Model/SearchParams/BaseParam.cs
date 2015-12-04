using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMKJ.FenLiu.Model.SearchParams
{
   public class BaseParam
    {
       public int PageIndex { get; set; }
       public int PageSize { get; set; }
       public int TotalCount { get; set; }
    }
}
