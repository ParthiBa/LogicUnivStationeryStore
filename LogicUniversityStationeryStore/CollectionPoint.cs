//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicUniversityStationeryStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class CollectionPoint
    {
        public CollectionPoint()
        {
            this.DisbursementLists = new HashSet<DisbursementList>();
        }
    
        public string place { get; set; }
        public System.TimeSpan timeSlot { get; set; }
        public int id { get; set; }
    
        public virtual ICollection<DisbursementList> DisbursementLists { get; set; }
    }
}