//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class membership_report_table
    {
        public System.DateTime start_date { get; set; }
        public System.DateTime end_date { get; set; }
        public int idforign { get; set; }
    
        public virtual new_member_table new_member_table { get; set; }
    }
}