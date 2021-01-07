using Xamarin.Essentials;

namespace travellingdollar
{
    public static class AppSettings
    {
        //google ads keys
        const string defaultAndroidAdsKey = "ca-app-pub-9800707284712065~6081346592";
        const string defaultIosAdsKey = "ca-app-pub-9800707284712065~1360337106";

        //google ads id's
        const string defaultAndroidAds = "ca-app-pub-9800707284712065/9386150877";
        const string defaultIosAds = "ca-app-pub-9800707284712065/9781752609"; 

        const string defaultInterstitialAndroid = "ca-app-pub-9800707284712065/7950938799"; 
        const string defaultInterstitialiOS = "ca-app-pub-9800707284712065/6012538147"; 

        const string defaultVideoAndroid = "ca-app-pub-9800707284712065/7383306043"; 
        const string defaultVideoiOS = "ca-app-pub-9800707284712065/8537779079"; 




        //AppsFlyer DeveloperKey
        const string defaultAppsFlyerDevKey = "mev2fD4zJwnzjJhAGYd3SH";

        //Other services
        const string defaultCognitiveServiceKey = "27a4453a28ab4df8af50d22fed37bcc0";
        const string defaultGooglePlacesApiKey = "AIzaSyAA5f_usWVL2jbldPd4KDKFFZIrMuKYD6U";
        //Syncfusion
        const string defaultSyncfucionKey = "Mzc5NDg1QDMxMzgyZTM0MmUzMGlMRFQ1OG9jL01sVEtJS3RkQXFGMC9LQ0VzdEZsOENtRDR4VnU0a2k2aGs9";

        //APP Center
        const string defaultAPPCenterANDROIDKey = "fb3f5766-2b1d-420c-9d88-bba2cdf18545;ios=e66422fd-f819-4acd-b6da-3b2ec73fd9c8";
        const string defautlAPPCENTERiOSKey = "e66422fd-f819-4acd-b6da-3b2ec73fd9c8";

        //Display only one interstitial per sesion
        const bool defaultshowintertitial = true;

        //EndPoints
        static readonly string defautlSearchEndPoint;
        static readonly string defaultUserEndPoint;
        static readonly string defaultUploadsEndPoint;
        static readonly string defaultMintsEndPoint;
        static readonly string defaultCoginitiveServiceEndPoint;
        static readonly string defaultSMSEndPoint;
        static readonly string defaultGoogleBaseEndPoint;
        static readonly string defaultNotificationEndPoint;
        static readonly string BaseAddress;

        static AppSettings()
        {
            
            BaseAddress = "https://travellingdollarwebapi.azurewebsites.net";

          
           
            defautlSearchEndPoint = $"{BaseAddress}/api/notes/";
            defaultUserEndPoint = $"{BaseAddress}/api/users/";
            defaultUploadsEndPoint = $"{BaseAddress}/api/Uploads/";
            defaultMintsEndPoint = $"{BaseAddress}/api/mints/";
            defaultSMSEndPoint = $"{BaseAddress}/api/sms";
            defaultNotificationEndPoint = $"{BaseAddress}/api/notifications/";
            defaultCoginitiveServiceEndPoint = "https://southcentralus.api.cognitive.microsoft.com/";
            defaultGoogleBaseEndPoint = "https://maps.googleapis.com/maps/";
            


        }

        //Properties
        public static string AndroidAdsKey
        {
            get => Preferences.Get(nameof(AndroidAdsKey), defaultAndroidAdsKey);
            set => Preferences.Set(nameof(AndroidAdsKey), value);
        }

        public static string IosAdsKey
        {
            get => Preferences.Get(nameof(IosAdsKey), defaultIosAdsKey);
            set => Preferences.Set(nameof(IosAdsKey), value);
        }

        public static string AndroidAds
        {
            get => Preferences.Get(nameof(AndroidAds), defaultAndroidAds);
            set => Preferences.Set(nameof(AndroidAds), value);
        }

        public static string IosAds
        {
            get => Preferences.Get(nameof(IosAds), defaultIosAds);
            set => Preferences.Set(nameof(IosAds), value);
        }


        public static string InterstitialAndroid
        {
            get => Preferences.Get(nameof(InterstitialAndroid), defaultInterstitialAndroid);
            set => Preferences.Set(nameof(InterstitialAndroid), value);
        }

        public static string InterstitialiOS
        {
            get => Preferences.Get(nameof(InterstitialiOS), defaultInterstitialiOS);
            set => Preferences.Set(nameof(InterstitialiOS), value);
        }

        public static string RewardVideoAndroid
        {
            get => Preferences.Get(nameof(RewardVideoAndroid), defaultVideoAndroid);
            set => Preferences.Set(nameof(RewardVideoAndroid), value);
        }
        public static string RewardVideoiOS
        {
            get => Preferences.Get(nameof(RewardVideoiOS), defaultVideoiOS);
            set => Preferences.Set(nameof(RewardVideoiOS), value);
        }

        public static string AppsFlyerDevKey
        {
            get => Preferences.Get(nameof(AppsFlyerDevKey), defaultAppsFlyerDevKey);
            set => Preferences.Set(nameof(AppsFlyerDevKey), value);
        }


        public static string CognitiveServiceKey
        {
            get => Preferences.Get(nameof(CognitiveServiceKey), defaultCognitiveServiceKey);
            set => Preferences.Set(nameof(CognitiveServiceKey), value);
        }

        public static string GooglePlacesApiKey
        {
            get => Preferences.Get(nameof(GooglePlacesApiKey), defaultGooglePlacesApiKey);
            set => Preferences.Set(nameof(GooglePlacesApiKey), value);
        }

        public static string SyncfusionKey
        {
            get => Preferences.Get(nameof(SyncfusionKey), defaultSyncfucionKey);
            set => Preferences.Set(nameof(SyncfusionKey), value);
        }
        public static string APPCenterAndroidKey
        {
            get => Preferences.Get(nameof(APPCenterAndroidKey), defaultAPPCenterANDROIDKey);
            set => Preferences.Set(nameof(APPCenterAndroidKey), value);
        }
        public static string APPCenteriOSKey
        {
            get => Preferences.Get(nameof(APPCenteriOSKey), defautlAPPCENTERiOSKey);
            set => Preferences.Set(nameof(APPCenteriOSKey), value);
        }

        public static bool ShowInterstitial
        {
            get => Preferences.Get(nameof(ShowInterstitial), defaultshowintertitial);
            set => Preferences.Set(nameof(ShowInterstitial), value);
        }

        public static string SearchEndPoint
        {
            get => Preferences.Get(nameof(SearchEndPoint), defautlSearchEndPoint);
            set => Preferences.Set(nameof(SearchEndPoint), value);
        }

        public static string UserEndPoint
        {
            get => Preferences.Get(nameof(UserEndPoint), defaultUserEndPoint);
            set => Preferences.Set(nameof(UserEndPoint), value);
        }

        public static string UploadsEndPoint
        {
            get => Preferences.Get(nameof(UploadsEndPoint), defaultUploadsEndPoint);
            set => Preferences.Set(nameof(UploadsEndPoint), value);
        }

        public static string MintsEndPoint
        {
            get => Preferences.Get(nameof(MintsEndPoint), defaultMintsEndPoint);
            set => Preferences.Set(nameof(MintsEndPoint), value);
        }



        public static string CognitiveServiceEndPoint
        {
            get => Preferences.Get(nameof(CognitiveServiceEndPoint), defaultCoginitiveServiceEndPoint);
            set => Preferences.Set(nameof(CognitiveServiceEndPoint), value);
        }

        public static string SMSEndPoint
        {
            get => Preferences.Get(nameof(SMSEndPoint), defaultSMSEndPoint);
            set => Preferences.Set(nameof(SMSEndPoint), value);
        }

        public static string GoogleBaseEndPoint
        {
            get => Preferences.Get(nameof(GoogleBaseEndPoint), defaultGoogleBaseEndPoint);
            set => Preferences.Set(nameof(GoogleBaseEndPoint), value);
        }

        public static string NotificationEndPoint
        {
            get => Preferences.Get(nameof(NotificationEndPoint), defaultNotificationEndPoint);
            set => Preferences.Set(nameof(NotificationEndPoint), value);
        }



    }
}
