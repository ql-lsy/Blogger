//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Blogger.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blog
    {
        public int BlogID { get; set; }
        public string BlogDec { get; set; }
        public string BlogContent { get; set; }
        public string BlogTitle { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> BlogClicks { get; set; }
        public Nullable<System.DateTime> BlogTime { get; set; }
        public string BlogImageUrl { get; set; }
        public Nullable<int> BlogLike { get; set; }
        public Nullable<int> BlogForword { get; set; }
        public Nullable<int> LabelID { get; set; }
        public Nullable<System.DateTime> LastTime { get; set; }
        public Nullable<int> LastClicks { get; set; }
    }
}
