using UnityEngine;

namespace JAMURR
{
    /// <summary>
    /// deactivate the assigned game object if the game isn't running in the designed platform
    /// </summary>
    public class PlatformVisibility : MonoBehaviour
    {
        public bool DesktopOnly;
        public bool MobileOnly;
        public bool AndroidOnly;
        public bool iOSOnly;

        void Start()
        {
            if (!Application.isEditor) {
                if (DesktopOnly && !isDesktopPlatform()) {
                    gameObject.SetActive(false);
                }
                if (MobileOnly && !isMobilePlatform()) {
                    gameObject.SetActive(false);
                }
                if (AndroidOnly && Application.platform != RuntimePlatform.Android) {
                    gameObject.SetActive(false);
                }
                if (iOSOnly && Application.platform != RuntimePlatform.IPhonePlayer) {
                    gameObject.SetActive(false);
                }
            }
        }

        bool isDesktopPlatform()
        {
            return (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer);
        }

        bool isMobilePlatform()
        {
            return (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer);
        }
    }
}