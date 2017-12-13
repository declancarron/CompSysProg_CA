//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnitTestHousing
{
    using System;
    using System.Collections.Generic;
    
    public partial class Apartment
    {
        public string ApartmentID { get; set; }
        public string ApartmentNumber { get; set; }
        public string CategoryID { get; set; }
        public string BuildingID { get; set; }
        public string VillageID { get; set; }
        public Nullable<int> NumberOfRooms { get; set; }
        public Nullable<int> RoomOccupancy { get; set; }
        public Nullable<int> TotalRoomOccupancy { get; set; }
        public string RoomAvailable { get; set; }
        public string OccupancyType { get; set; }
        public string VillageName { get; set; }
        public string AirCon { get; set; }
        public string RoomType { get; set; }
        public string Furnished { get; set; }
        public string Dishwasher { get; set; }
        public string Address1 { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
    
        public virtual Building Building { get; set; }
        public virtual Village Village { get; set; }
    }
}
