
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
        public const string AppVersion = "1.2.0";

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
        public static bool UseUnityAnalytics = true;

        /// <summary>
        /// Switches on all Debug.Log calls for performance.
        /// Set to FALSE for production.
        /// </summary>
        public static bool VerboseLogging = true;
        #endregion

        // public URLs
        public const string UrlWebsite = "http://jamurr.org/project/7-frames/";
        public const string UrlPrivacy = "http://www.jamurr.org/privacy/";
        public const string UrlStoreiOSApple = "https://itunes.apple.com/us/app/7-frames/id1239225688?ls=1&mt=8";
        public const string UrlStoreAndroidGoogle = "https://play.google.com/store/apps/details?id=org.jamurr.sevenframes";
        public const string UrlCommunityTelegram = "https://t.me/jamurr";
        public const string UrlCommunityFacebook = "https://www.facebook.com/JAMURR.org";
        public const string UrlSupportForm = "https://docs.google.com/forms/d/1nDByCkT7GSWvRkrCkesIbMiHog8s_3eoAfYgI3rYlcE";
        public const string UrlGithubRepository = "https://github.com/JAMURR/JAM.7FRAMES";
    }
}