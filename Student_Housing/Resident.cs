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
    
    public partial class Resident
    {
        public string ResidentId { get; set; }
        public string UserID { get; set; }
        public string BuildingID { get; set; }
        public string ApartmentNumber { get; set; }
        public string College { get; set; }
        public string Department { get; set; }
        public string MartialStatus { get; set; }
        public string DepositPaid { get; set; }
        public float DepositAmount { get; set; }
        public System.DateTime DepositPaymentDate { get; set; }
        public string RentFrequency { get; set; }
        public float RentAmount { get; set; }
        public Nullable<System.DateTime> LastRentPaid { get; set; }
        public string RentOverdue { get; set; }
        public float RentArrears { get; set; }
    }
}