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
    
    public partial class TbApplyMajor
    {
        public string ApplyMajorId { get; set; }
        public string StudentId { get; set; }
        public string MajorId { get; set; }
        public string ToApplyMajorId { get; set; }
        public string ApplyReason { get; set; }
        public Nullable<int> IsDone { get; set; }
        public string DealUserId { get; set; }
        public Nullable<System.DateTime> DealTime { get; set; }
        public Nullable<int> DelFlag { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    }
}
