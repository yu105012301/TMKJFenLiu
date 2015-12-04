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
    
    public partial class TbStudent
    {
        public TbStudent()
        {
            this.TbDesire = new HashSet<TbDesire>();
            this.TbInterviewScore = new HashSet<TbInterviewScore>();
            this.TbLessionScore = new HashSet<TbLessionScore>();
            this.TbQuestion = new HashSet<TbQuestion>();
            this.TbRecord = new HashSet<TbRecord>();
            this.TbStudentClass = new HashSet<TbStudentClass>();
            this.TbTotalScore = new HashSet<TbTotalScore>();
        }
    
        public string StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentPwd { get; set; }
        public string StudentName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<int> Gender { get; set; }
        public int SysRole { get; set; }
        public string MajorId { get; set; }
        public int Grade { get; set; }
        public Nullable<int> DelFlag { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> ModifyTime { get; set; }
    
        public virtual ICollection<TbDesire> TbDesire { get; set; }
        public virtual ICollection<TbInterviewScore> TbInterviewScore { get; set; }
        public virtual ICollection<TbLessionScore> TbLessionScore { get; set; }
        public virtual ICollection<TbQuestion> TbQuestion { get; set; }
        public virtual ICollection<TbRecord> TbRecord { get; set; }
        public virtual ICollection<TbStudentClass> TbStudentClass { get; set; }
        public virtual ICollection<TbTotalScore> TbTotalScore { get; set; }
    }
}
