//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMKJ.FenLiu.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TbInterviewScore
    {
        public string InterviewScoreId { get; set; }
        public string StudentId { get; set; }
        public double InterviewScore { get; set; }
        public Nullable<int> DelFlag { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual TbStudent TbStudent { get; set; }
    }
}
