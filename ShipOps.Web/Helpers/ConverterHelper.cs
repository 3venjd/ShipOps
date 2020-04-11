using ShipOps.Common.Models;
using ShipOps.Web.Data.Entities;
using System.Linq;

namespace ShipOps.Web.Helpers
{
    public class ConverterHelper : IConverterHerlper
    {
        public CompanyResponse ToCompanyResponse(CompanyEntity companyEntity)
        {
            return new CompanyResponse
            {
                Id = companyEntity.Id,
                Country = companyEntity.Country,
                Name = companyEntity.Name,
                Pro = companyEntity.Pro,
                Clients = companyEntity.Clients?.Select(cl => new UserResponse
                {
                    Id = cl.Id,
                    Document = cl.Document,
                    FirstName = cl.FirstName,
                    LastName = cl.LastName,
                    PicturePath = cl.PicturePath,
                    UserType = cl.UserType,
                    Office = null
                }).ToList(),
                Voys = companyEntity.Voys?.Select(v => new VoyResponse
                {
                    Id = v.Id,
                    Voy_number = v.Voy_number,
                    Account = v.Account,
                    Laycan = v.Laycan,
                    Contract = v.Contract,
                    Cargo = v.Cargo,
                    Sf = v.Sf,
                    Pol = v.Pol,
                    Facility = v.Facility,
                    Pod = v.Pod,
                    Cargo_Charterer = v.Cargo_Charterer,
                    Owner_Charterer = v.Owner_Charterer,
                    Shipper = v.Shipper,
                    Consignee = v.Consignee,
                    Latitude = v.Latitude,
                    Altitude = v.Altitude,
                    LastKnowPosition = v.LastKnowPosition,
                    Eta = v.Eta,
                    Etb = v.Etb,
                    Etc = v.Etc,
                    Etd = v.Etd,
                    Employee = ToEmployeeResponse(v.Employee),
                    Port = ToPortResponse(v.Port),
                    Vessel = ToVesselResponse(v.Vessel),
                    Statuses = v.Statuses?.Select(s => new StatusResponse
                    {
                        Id = s.Id,
                        Name_status = s.Name_status,
                        Arrival = s.Arrival,
                        Anchored = s.Anchored,
                        Pob = s.Pob,
                        AllFast = s.AllFast,
                        Commenced = s.Commenced,
                        DateUpdate = s.DateUpdate,
                        Holds = s.Holds?.Select(h => new HoldResponse
                        {
                            Id = h.Id,
                            Hold_Number = h.Hold_Number,
                            Actual_Quantity = h.Actual_Quantity,
                            Max_Quantity = h.Max_Quantity,
                            Is_Full = h.Is_Full,
                            Is_Empty = h.Is_Empty,
                            First_Charge = h.First_Charge,
                            Last_Charge = h.Last_Charge
                        }).ToList(),
                        Alerts = s.Alerts?.Select(a => new AlertResponse
                        {
                            Id = a.Id,
                            Alert_Description = a.Alert_Description,
                            Alert_Date = a.Alert_Date,
                            AlertImages = a.AlertImages?.Select(ai => new AlertImageResponse
                            {
                                Id = ai.Id,
                                Title = ai.Title,
                                ImageUrl = ai.ImageUrl
                            }).ToList()
                        }).ToList()
                    }).ToList(),
                    Opinions = v.Opinions?.Select(o => new OpinionResponse
                    {
                        Id = o.Id,
                        Description = o.Description,
                        Qualification = o.Qualification,
                    }).ToList(),
                    TripDetails = v.TripDetails?.Select(td => new TripDetailResponse
                    {
                        Id = td.Id,
                        Date = td.Date,
                        Altitude = td.Altitude,
                        Latitude = td.Latitude
                    }).ToList(),
                    Voyimages = v.Voyimages?.Select(vi => new VoyImageResponse
                    {
                        Id = vi.Id,
                        Title = vi.Title,
                        ImageUrl = vi.ImageUrl
                    }).ToList()
                }).ToList()
            };
        }

        private VesselResponse ToVesselResponse(VesselEntity vessel)
        {
            if (vessel == null)
            {
                return null;
            }

            return new VesselResponse
            {
                Id = vessel.Id,
                Vessel_Name = vessel.Vessel_Name,
                ImageUrl = vessel.ImageUrl,
                vesselType = ToVesselTypeResponse(vessel.VesselType)
            };
        }

        private VesselTypeResponse ToVesselTypeResponse(VesselTypeEntity vesselType)
        {
            if (vesselType == null)
            {
                return null;
            }

            return new VesselTypeResponse
            {
                Id = vesselType.Id,
                Type_Vessel = vesselType.Type_Vessel
            };
        }

        private PortResponse ToPortResponse(PortEntity port)
        {
            if (port == null)
            {
                return null;
            }

            return new PortResponse
            {
                Id = port.Id,
                Port_Name = port.Port_Name,
                ImageUrl = port.ImageUrl,
                Terminals = port.Terminals?.Select(t => new TerminalResponse
                {
                    Id = t.Id,
                    Terminal_Name = t.Terminal_Name,
                    Max_Loa = t.Max_Loa,
                    Max_Beam = t.Max_Beam,
                    Max_Draft = t.Max_Draft,
                    Displacement = t.Displacement,
                    Water_Density = t.Water_Density,
                    Working_hours = t.Working_hours,
                    Type_Cargo = t.Type_Cargo,
                    ImageUrl = t.ImageUrl,
                    LineUps = t.LineUps?.Select(l => new LineUpResponse
                    {
                        Id = l.Id,
                        Vessel = l.Vessel,
                        Eta = l.Eta,
                        Etb = l.Etb,
                        Etc = l.Etc,
                        Etd = l.Etd,
                        Status = l.Status,
                        Cargo = l.Cargo,
                        Quantity = l.Quantity,
                        Laycan = l.Laycan,
                        Pol_Pod = l.Pol_Pod,
                        Shipper_Consignee = l.Shipper_Consignee,
                        Cargo_Charterer = l.Cargo_Charterer,
                        Agency = l.Agency
                    }).ToList()
                }).ToList()
            };
        }

        private UserResponse ToEmployeeResponse(UserEntity employee)
        {
            if (employee == null)
            {
                return null;
            }

            return new UserResponse
            {
                Id = employee.Id,
                Document = employee.Document,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PicturePath = employee.PicturePath,
                UserType = employee.UserType,
                Office = ToOfficeResponse(employee.Office)
            };
        }

        private OfficeResponse ToOfficeResponse(OfficeEntity office)
        {
            if (office == null)
            {
                return null;
            }

            return new OfficeResponse
            {
                Id = office.Id,
                Name = office.Name,
                Adress = office.Adress,
                Postal_Code = office.Postal_Code,
                Phone = office.Phone,
                Usa_Phone = office.Usa_Phone,
                Email = office.Email
            };
        }

        public NewsResponse ToNewResponse(NewEntity newEntity)
        {
            return new NewsResponse
            {
                Id = newEntity.Id,
                Title = newEntity.Title,
                Description = newEntity.Description,
                DatePublication = newEntity.DatePublication,
                NewImages = newEntity.NewImages?.Select(ni => new NewImageResponse
                {
                    Id = ni.Id,
                    ImageUrl = ni.ImageUrl
                }).ToList()

            };
        }
    }
}
