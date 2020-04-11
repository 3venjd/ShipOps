using ShipOps.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShipOps.Common.Models
{
    public class UserResponse
    {
        public string Id { get; set; }

        public string Document { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string PicturePath { get; set; }

        public UserType UserType { get; set; }

        public OfficeResponse Office { get; set; }

    }
}
