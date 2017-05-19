
namespace JAMURR
{
    /// <summary>
    /// Container for application-wide static constants.
    /// </summary>
    public static class AppConstants
    {

        /// <summary>
        /// Version of the application.
        /// </summary>
        public const string AppVersion = "1.0.0";

        #region Debug Options

        /// <summary>
        /// Enabled the Advanced Debug Panel.
        /// Set to FALSE for production.
        /// </summary>
        public const bool DebugPanelEnabled = false;

        /// <summary>
        /// Tracks common events using Unity Analytics.
        /// Set to TRUE for production.
        /// </summary>
        public static bool UseUnityAnalytics = false;

        /// <summary>
        /// Switches on all Debug.Log calls for performance.
        /// Set to FALSE for production.
        /// </summary>
        public static bool VerboseLogging = true;
        #endregion

        // public URLs
        public const string UrlWebsite = "http://jamurr.org/project/7-frames/";
        public const string UrlPrivacy = "http://www.jamurr.org/privacy/";
        public const string UrlStoreiOSApple = "";
        public const string UrlStoreAndroidGoogle = "https://play.google.com/store/apps/details?id=org.jamurr.sevenframes";
        public const string UrlCommunityTelegram = "https://t.me/jamurr";
        public const string UrlCommunityFacebook = "https://www.facebook.com/JAMURR.org";
        public const string UrlSupportForm = "";
        public const string UrlGithubRepository = "https://github.com/JAMURR/JAM.7FRAMES";
    }
}