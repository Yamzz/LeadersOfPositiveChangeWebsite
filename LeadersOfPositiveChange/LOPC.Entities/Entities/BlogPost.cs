//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LOPC.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class BlogPost
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Post { get; set; }
        public System.DateTime DateTime { get; set; }
        public string PostedBy { get; set; }
        public string Image { get; set; }
    }
}
