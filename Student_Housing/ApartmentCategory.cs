//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student_Housing
{
    using System;
    using System.Collections.Generic;
    
    public partial class ApartmentCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApartmentCategory()
        {
            this.Apartments = new HashSet<Apartment>();
        }
    
        public string CategoryID { get; set; }
        public string AirCon { get; set; }
        public string RoomType { get; set; }
        public string Furnished { get; set; }
        public string Dishwasher { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
