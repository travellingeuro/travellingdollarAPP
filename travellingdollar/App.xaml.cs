using MarcTron.Plugin;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.Ioc;
using travellingdollar.Services.AddNote;
using travellingdollar.Services.Dialogs;
using travellingdollar.Services.Notification;
using travellingdollar.Services.Request;
using travellingdollar.Services.Scan;
using travellingdollar.Services.SearchNote;
using travellingdollar.Services.SearchPlace;
using travellingdollar.Services.SMS;
using travellingdollar.Services.User;
using travellingdollar.ViewModels;
using travellingdollar.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace travellingdollar
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            AppCenter.Start($"android={AppSettings.APPCenterAndroidKey};ios={AppSettings.APPCenteriOSKey}",
                typeof(Analytics), typeof(Crashes));

            CrossMTAdmob.Current.UserPersonalizedAds = true;
            CrossMTAdmob.Current.ComplyWithFamilyPolicies = true;
            CrossMTAdmob.Current.UseRestrictedDataProcessing = true;
            AppSettings.ShowInterstitial = true;
            CrossMTAdmob.Current.AdsId = DeviceInfo.Platform == DevicePlatform.iOS ? AppSettings.IosAds : AppSettings.AndroidAds;

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            AppSettings.ShowInterstitial = true;
        }

        protected override void OnResume()
        {
            base.OnResume();
            AppSettings.ShowInterstitial = true;
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Pages
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PresentationPage, PresentationPageViewModel>();
            containerRegistry.RegisterForNavigation<SearchNotePage, SearchNotePageViewModel>();
            containerRegistry.RegisterForNavigation<SpecimenPage, SpecimenPageViewModel>();
            containerRegistry.RegisterForNavigation<AddNote, AddNoteViewModel>();
            containerRegistry.RegisterForNavigation<ViewUpload, ViewUploadViewModel>();
            containerRegistry.RegisterForNavigation<Stats, StatsViewModel>();
            containerRegistry.RegisterForNavigation<MapNotePage, MapNotePageViewModel>();

            //Services
            containerRegistry.Register<IDialogService, DialogService>();
            containerRegistry.Register<IRequestService, RequestService>();
            containerRegistry.Register<IScanService, ScanService>();
            containerRegistry.Register<ISearchNote, SearchNote>();
            containerRegistry.Register<ISmsService, SmsService>();
            containerRegistry.Register<IUserService, UserService>();
            containerRegistry.Register<IAddNoteService, AddNoteService>();
            containerRegistry.Register<ISearchPlace, SearchPlace>();
            containerRegistry.Register<INotificationService, NotificationService>();
            
        }
    }

}
