﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboVesselType();

        //IEnumerable<SelectListItem> GetComboEmployees();

        IEnumerable<SelectListItem> GetComboPorts();

        IEnumerable<SelectListItem> GetComboVessels();
    }
}
