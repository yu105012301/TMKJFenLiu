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
    
    public partial class TbRecord
    {
        public string RecordId { get; set; }
        public string StudentId { get; set; }
        public string BeforeMajorId { get; set; }
        public string BeforeClassId { get; set; }
        public string AfterMajorId { get; set; }
        public string AfterClassId { get; set; }
        public Nullable<int> Stage { get; set; }
        public Nullable<int> DelFlag { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual TbClass TbClass { get; set; }
        public virtual TbClass TbClass1 { get; set; }
        public virtual TbMajor TbMajor { get; set; }
        public virtual TbMajor TbMajor1 { get; set; }
        public virtual TbStudent TbStudent { get; set; }
    }
}
