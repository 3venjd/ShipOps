﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShipOps.Common.Models
{
    public class CompanyResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public bool Pro { get; set; }

        public List<UserResponse> Clients { get; set; }

        public List<VoyResponse> Voys { get; set; }
    }
}
