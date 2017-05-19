using UnityEngine;
using TMPro;

namespace JAMURR
{
    /// <summary>
    /// Shows the version of the application.
    /// </summary>
    public class AppVersionLabel : MonoBehaviour
    {
        void Start()
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "v " + AppConstants.AppVersion;
        }
    }
}