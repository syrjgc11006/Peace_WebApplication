using System;
using System.Collections.Generic;

namespace Peace.Data
{
    public partial class Address:BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateProvinceId { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string CustomAttributes { get; set; }
        public System.DateTime CreatedOnUtc { get; set; }
        public System.DateTime ModifyTime { get; set; }
        public Nullable<int> User_Id { get; set; }
        public virtual User User { get; set; }
    }
}
