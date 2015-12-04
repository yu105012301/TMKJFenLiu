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
    
    public partial class TbMajor
    {
        public TbMajor()
        {
            this.TbClass = new HashSet<TbClass>();
            this.TbDesire = new HashSet<TbDesire>();
            this.TbDesire1 = new HashSet<TbDesire>();
            this.TbDesire2 = new HashSet<TbDesire>();
            this.TbQuestion = new HashSet<TbQuestion>();
            this.TbRecord = new HashSet<TbRecord>();
            this.TbRecord1 = new HashSet<TbRecord>();
        }
    
        public string MajorId { get; set; }
        public int MajorNumber { get; set; }
        public string MajorName { get; set; }
        public string MajorMark { get; set; }
        public int MajorCount { get; set; }
        public Nullable<int> DelFlag { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual ICollection<TbClass> TbClass { get; set; }
        public virtual ICollection<TbDesire> TbDesire { get; set; }
        public virtual ICollection<TbDesire> TbDesire1 { get; set; }
        public virtual ICollection<TbDesire> TbDesire2 { get; set; }
        public virtual ICollection<TbQuestion> TbQuestion { get; set; }
        public virtual ICollection<TbRecord> TbRecord { get; set; }
        public virtual ICollection<TbRecord> TbRecord1 { get; set; }
    }
}