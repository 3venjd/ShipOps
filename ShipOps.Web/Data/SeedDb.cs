using ShipOps.Common.Enumerations;
using ShipOps.Web.Data.Entities;
using ShipOps.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext, IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();

            await CheckRolesAsync();
            await CheckUserAsync("7854934563", "Evelio", "Jimenez", "lui.eve.jim.dur@gmail.com", "3124348945", UserType.Admin);
            await CheckUserAsync("1043244567", "JR", "Lopez", "jeyarelo@hotmail.com", "3124348945", UserType.Client);
            var employee = await CheckUserAsync("9452094523", "Santiago", "Franco", "dejesusrock@hotmail.com", "3124348945", UserType.Employee);
            
            
            await CheckCompanyAsync();
            await CheckOffice();
            await CheckPortAsync();
            await CheckVesselTypeAsync();
            await CheckVesselAsync();
            await CheckVoyAsync(employee);
            await CheckTripDetailAsync();
            await CheckOpinionAsync();
            await CheckVoyImageAsync();
            await CheckStatusAsync();
            await CheckAlertAsync();
            await CheckAlerImagetAsync();
            await CheckNewAsync();
            await CheckNewImageAsync();
            await CheckTerminalAsync();
            await CheckHoldAsync();
            await CheckLineUpAsync();


        }

        private async Task<UserEntity> CheckUserAsync(string document,
                                                      string first_name,
                                                      string last_name,
                                                      string email,
                                                      string cellphone,
                                                      UserType userType)
        {
            var user = await _userHelper.GetUserByEmail(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = first_name,
                    LastName = last_name,
                    Email = email,
                    UserName = email,
                    Document = document,
                    PhoneNumber = cellphone,
                    UserType = userType,
                    

                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Client.ToString());
            await _userHelper.CheckRoleAsync(UserType.Employee.ToString());
        }

        private async Task CheckTripDetailAsync()
        {
            var voy = _dataContext.Voys.FirstOrDefault();

            if (!_dataContext.Alerts.Any())
            {
                AddTripDetail(DateTime.Parse("12/04/2018"), 324.4, 532.3, voy);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddTripDetail(DateTime date, double latitude, double altitude, VoyEntity voy)
        {
            _dataContext.TripDetails.Add(new TripDetailEntity
            {
                Date = date,
                Latitude = latitude,
                Altitude = altitude,
                Voy = voy
            });
        }

        private async Task CheckOpinionAsync()
        {
            var voy = _dataContext.Voys.FirstOrDefault();
            if (!_dataContext.Opinions.Any())
            {
                _dataContext.Opinions.Add(new OpinionEntity { Qualification = 4, Description = "Amazing service", Voy = voy });
                
            }
            await _dataContext.SaveChangesAsync();
        }

        
        private async Task CheckAlertAsync()
        {
            var status = _dataContext.Statuses.FirstOrDefault();
            if (!_dataContext.Alerts.Any())
            {
                AddAlert(DateTime.Parse("12/04/2018"), "Photo about Alert in Operation", status);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddAlert(DateTime alert_date, string description, StatusEntity status)
        {
            _dataContext.Alerts.Add(new AlertEntity
            {
                Alert_Date = alert_date,
                Alert_Description = description,
                Status = status,
            }
            );
        }

        private async Task CheckAlerImagetAsync()
        {
            var alert = _dataContext.Alerts.FirstOrDefault();

            AddAlertImage("Alert 1", "https://www.mmaoffshore.com/sites/mmaoffshorecomau//" +
                "assets/public/image/ProductListing/Thumbnails/14ad7e97-12e7-4bf4-a610-" +
                "acbdde9ee220-mermaid-leeuwin.jpg", alert);

            await _dataContext.SaveChangesAsync();
        }

        private void AddAlertImage(string title, string URL, AlertEntity alert)
        {
            _dataContext.AlertImages.Add(new AlertImageEntity
            {
                Title = title,
                ImageUrl = URL,
                Alert = alert,
            });
        }

        private async Task CheckCompanyAsync()
        {
            if (!_dataContext.Companies.Any())
            {
                _dataContext.Companies.Add(new CompanyEntity
                {
                    Name = "Hyundai",
                    Country = "China",
                    Pro = true,

                });
            }
            await _dataContext.SaveChangesAsync();
        }

      

        private async Task CheckHoldAsync()
        {
            var status = _dataContext.Statuses.FirstOrDefault();

            if (!_dataContext.Holds.Any())
            {
                AddHold(1, 3023, 2500, false, true, status);

                AddHold(2, 4566, 30000, false, true, status);

                AddHold(3, 2456, 20000, false, true, status);

                AddHold(4, 5678, 3500, false, true, status);

                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddHold(int hold_n, int actual_quantity, int max_quantity, bool full, bool empty, StatusEntity status)
        {
            _dataContext.Holds.Add(new HoldEntity
            {
                Hold_Number = hold_n,
                Actual_Quantity = actual_quantity,
                Max_Quantity = max_quantity,
                Is_Full = full,
                Is_Empty = empty,
                Status = status,

            }
           );
        }

        private async Task CheckLineUpAsync()
        {
            var terminal = _dataContext.Terminals.FirstOrDefault();

            if (!_dataContext.LineUps.Any())
            {

                AddLineUp("Sean Jhon", DateTime.Parse("06/06/2019"), DateTime.Parse("10/06/2019"),
                    DateTime.Parse("02/07/2019"), DateTime.Parse("02/07/2019"), "In Progress", "Steel",
                    "450000", "02/06/2019 - 02/07/2019", "Ravenna,Italy", "Cargil", "Allied Chemical Carriers",
                    "Ship Company", terminal);


                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddLineUp(string vessel, DateTime eta, DateTime etb, DateTime etc, DateTime etd, string status, string cargo, string quantity, string laycan, string pol_pod, string shipperconsig, string cargo_char, string agency, TerminalEntity terminal)
        {
            _dataContext.LineUps.Add(new LineUpEntity
            {
                Vessel = vessel,
                Eta = eta,
                Etb = etb,
                Etc = etc,
                Etd = etd,
                Status = status,
                Cargo = cargo,
                Quantity = quantity,
                Laycan = laycan,
                Pol_Pod = pol_pod,
                Shipper_Consignee = shipperconsig,
                Cargo_Charterer = cargo_char,
                Agency = agency,
                Terminal = terminal,

            }
            );
        }

        private async Task CheckNewAsync()
        {
            if (!_dataContext.News.Any())
            {
                AddNew("Bigges Ship in Colombia", "Lorem Ipsum is simply dummy text of " +
                    "the printing and typesetting industry. " +
                    "Lorem Ipsum has been the industry's standard " +
                    "dummy text ever since the 1500s, when an unknown " +
                    "printer took a galley of type and scrambled it to " +
                    "make a type specimen book. It has survived not only " +
                    "five centuries, but also the leap into electronic typesetting," +
                    " remaining essentially unchanged. It was popularised in the 1960s " +
                    "with the release of Letraset sheets containing Lorem Ipsum passages" +
                    "and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                    DateTime.Parse("02/02/2019")
                    );

                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddNew(string title, string descripion, DateTime DatePlublication)
        {
            _dataContext.News.Add(new NewEntity
            {
                Title = title,
                Description = descripion,
                DatePublication = DatePlublication,
            }
           );
        }

        private async Task CheckNewImageAsync()
        {
            var newn = _dataContext.News.FirstOrDefault();

            if (!_dataContext.NewImages.Any())
            {
                _dataContext.NewImages.Add
                (
                    new NewImageEntity
                    {
                        ImageUrl = "https://www.mmaoffshore.com/sites/mmaoffshorecomau//assets/" +
                    "public/image/ProductListing/Thumbnails/bb5781bb-24c8-4a8b-b1e2-d6ef4a507c9e-mma" +
                    "-prestige.jpg",
                        New = newn,
                    }
                );
                
            }
            await _dataContext.SaveChangesAsync();
        }
        private async Task CheckOffice()
        {
            if (!_dataContext.Offices.Any())
            {
                AddFullStyle("Medellin", "Calle 4 sur #43A-149", "050022", "+4 2688444", "340 8435674", "asistente@gmail.com");
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddFullStyle(string name, string address, string postalc, string localphone, string usaphone, string mainmail)
        {
            _dataContext.Offices.Add
                (
                    new OfficeEntity
                    {
                        Name = name,
                        Adress = address,
                        Postal_Code = postalc,
                        Phone = localphone,
                        Usa_Phone = usaphone,
                        Email = mainmail
                    }
                );
        }

        private async Task CheckPortAsync()
        {

            if (!_dataContext.Ports.Any())
            {
                AddPort("Barranquilla", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNNfRn7vJA30lD8uhLg7cSswDUqUBCQv0sWgyjL3WnCVQQOU27Wg");

                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddPort(string port_name, string URL)
        {
            _dataContext.Ports.Add(new PortEntity
            {
                Port_Name = port_name,
                ImageUrl = URL
            }
          );
        }

        private async Task CheckStatusAsync()
        {
            var voy = _dataContext.Voys.FirstOrDefault();
            if (!_dataContext.Statuses.Any())
            {
                AddStatus("In Progress", DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), DateTime.Parse("12/04/2018"), voy);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddStatus(String name_status, DateTime arrival, DateTime anchored, DateTime pob, DateTime allfast, DateTime commenced, DateTime dateupdate, VoyEntity voy)
        {
            _dataContext.Statuses.Add(new StatusEntity
            {
                Name_status = name_status,
                Arrival = arrival,
                Anchored = anchored,
                Pob = pob,
                AllFast = allfast,
                Commenced = commenced,
                DateUpdate = dateupdate,
                Voy = voy,
            }
            );
        }

        private async Task CheckTerminalAsync()
        {
            var port = _dataContext.Ports.FirstOrDefault();
            if (!_dataContext.Terminals.Any())
            {

                AddTerminal("Santa Marta", "338 MTS", "62 MTS", "22 MTS", "360,000 TONS", "SW", "24 HRS Shinc", "Crude Oil", "https://www.seaboardmarine.com/wp-content/uploads/We-Bring-You-Closer-To-Your-Customersoptm-1024x269.jpg", port);

                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddTerminal(string terminal_Name, string max_Loa, string max_Beam, string max_Draft, string displacement, string water_Density, string working_hours, string type_Cargo, string URL, PortEntity port)
        {
            _dataContext.Terminals.Add(new TerminalEntity
            {
                Terminal_Name = terminal_Name,
                Max_Loa = max_Loa,
                Max_Beam = max_Beam,
                Max_Draft = max_Draft,
                Displacement = displacement,
                Water_Density = water_Density,
                Working_hours = working_hours,
                Type_Cargo = type_Cargo,
                ImageUrl = URL,
                Port = port,
            }
            );
        }

        private async Task CheckVesselAsync()
        {
            var vesseltypes = _dataContext.VesselTypes.FirstOrDefault();

            if (!_dataContext.Vessels.Any())
            {
                AddVessel("Sean John",
                    "https://www.google.com/url?sa=i&source=images&cd=&ved=2ahUKEwj36IbivYrlAhUitlkKHUOSDAMQjRx6BAgBEAQ&url=https%3A%2F%2Fwww.fleetmon." +
                    "com%2Fservices%2Fvessel-risk-rating%2F&psig=AOvVaw1aRZobSnPtiAbIzDdc1TT0&ust=1570549178192912", vesseltypes);
                await _dataContext.SaveChangesAsync();
            }
        }

        private void AddVessel(string vessel_name, string URL, VesselTypeEntity vesselType)
        {
            _dataContext.Vessels.Add(new VesselEntity
            {
                Vessel_Name = vessel_name,
                ImageUrl = URL,
                VesselType = vesselType,

            }
            );

        }

        private async Task CheckVesselTypeAsync()
        {
            if (!_dataContext.VesselTypes.Any())
            {
                _dataContext.VesselTypes.Add(new VesselTypeEntity { Type_Vessel = "Container" });
                _dataContext.VesselTypes.Add(new VesselTypeEntity { Type_Vessel = "General" });
                _dataContext.VesselTypes.Add(new VesselTypeEntity { Type_Vessel = "Crude Oil" });

                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckVoyAsync(UserEntity employee)
        {

            var vessel = _dataContext.Vessels.FirstOrDefault();
            var company = _dataContext.Companies.FirstOrDefault();
            var port = _dataContext.Ports.FirstOrDefault();

            if (!_dataContext.Voys.Any())
            {
                _dataContext.Voys.Add(new VoyEntity
                {
                    Voy_number = 0,
                    Account = "Aes Gener S.A",
                    Laycan = "16 Jun - 20 Jun",
                    Contract = "70,000 mt +/- 10%",
                    Cargo = "Stream coal in bulk",
                    Sf = "abt 43 cuft/mt",
                    Pol = "Santa Marta, Colombia",
                    Facility = "Carbosan / spsm (pier7)",
                    Pod = "Huasco,Chile",
                    Cargo_Charterer = "Aes Gener S.A",
                    Owner_Charterer = "Glencore Agriculture BV",
                    Shipper = "Colombia Natural Resources",
                    Consignee = "Aes Gener S.A",
                    Latitude = 234.3,
                    Altitude = 534.4,
                    LastKnowPosition = DateTime.Parse("12/04/2018"),
                    Eta = DateTime.Parse("01/01/2018"),
                    Etb = DateTime.Parse("04/02/2018"),
                    Etc = DateTime.Parse("05/02/2018"),
                    Etd = DateTime.Parse("12/04/2018"),
                    Vessel = vessel,
                    Company = company,
                    Port = port,
                    Employee = employee,
                });

                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckVoyImageAsync()
        {
            var voy = _dataContext.Voys.FirstOrDefault();

            if (!_dataContext.Alerts.Any())
            {
                AddVoyImage("Voy 123", "https://www.mmaoffshore.com/sites/mmaoffshorecomau//assets/" +
                    "public/image/ProductListing/Thumbnails/7c082b61-2ee0-4c35-99cb-338ce4e4f97f-" +
                    "Pride%2011.jpg", voy);
                await _dataContext.SaveChangesAsync();
            }

        }

        private void AddVoyImage(string title, string URL, VoyEntity voy)
        {
            _dataContext.VoysImages.Add(new VoyImageEntity
            {
                Title = title,
                ImageUrl = URL,
                Voy = voy,

            }
            );
        }


    }
}
