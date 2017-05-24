using UnityEngine;
using System.Collections;

namespace JAMURR
{
    public class AppManager : MonoBehaviour
    {
        public static AppManager I;

        void Awake()
        {
            I = this;
        }

        void Start()
        {
        }

        public void ButtonContactForm()
        {
            Application.OpenURL(AppConstants.UrlSupportForm);
        }

        public void ButtonReview()
        {
            if (Application.platform == RuntimePlatform.Android) {
                Application.OpenURL(AppConstants.UrlStoreAndroidGoogle);
            }
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                Application.OpenURL(AppConstants.UrlStoreiOSApple);
            }
        }

        public void ButtonWebsite()
        {
            Application.OpenURL(AppConstants.UrlWebsite);
        }

        public void ButtonGitHub()
        {
            Application.OpenURL(AppConstants.UrlGithubRepository);
        }

        public void ButtonFacebook()
        {
            Application.OpenURL(AppConstants.UrlCommunityFacebook);
        }
    }
}