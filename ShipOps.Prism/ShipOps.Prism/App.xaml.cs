using Prism;
using Prism.Ioc;
using ShipOps.Common.Services;
using ShipOps.Prism.ViewModels;
using ShipOps.Prism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ShipOps.Prism
{
    public partial class App
    {

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("ShipOpsMasterDetailPage/NavigationPage/NewsPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.Register<IGeoLocatorService, GeoLocatorService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<AboutUsPage, AboutUsPageViewModel>();
            containerRegistry.RegisterForNavigation<AlertsPage, AlertsPageViewModel>();
            containerRegistry.RegisterForNavigation<FullStylePage, FullStylePageViewModel>();
            containerRegistry.RegisterForNavigation<LineUpsDetailPage, LineUpsDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<LineUpsPage, LineUpsPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<NewsDetailPage, NewsDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<NewsPage, NewsPageViewModel>();
            containerRegistry.RegisterForNavigation<OfficeDetailsPage, OfficeDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<OfficesPage, OfficesPageViewModel>();
            containerRegistry.RegisterForNavigation<PortsDetailsPage, PortsDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<PortsPage, PortsPageViewModel>();
            containerRegistry.RegisterForNavigation<RatePage, RatePageViewModel>();
            containerRegistry.RegisterForNavigation<StatusPage, StatusPageViewModel>();
            containerRegistry.RegisterForNavigation<TerminalsPage, TerminalsPageViewModel>();
            containerRegistry.RegisterForNavigation<VesselsPage, VesselsPageViewModel>();
            containerRegistry.RegisterForNavigation<VoysDetailsPage, VoysDetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<VoysPage, VoysPageViewModel>();
            containerRegistry.RegisterForNavigation<ShipOpsMasterDetailPage, ShipOpsMasterDetailPageViewModel>();
        }
    }
}
