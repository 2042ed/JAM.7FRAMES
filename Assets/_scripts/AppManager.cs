using UnityEngine;
using System.Collections;

public class AppManager : MonoBehaviour
{
    public static AppManager I;
    public GameObject MapJam;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        MapJam.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("m")) {
            MapJam.SetActive(true);
        }
        if (Input.GetKeyUp("m")) {
            MapJam.SetActive(false);
        }

    }

    public void ToggleMap()
    {
        if (MapJam.activeSelf) {
            HideMap();
        } else {
            ShowMap();
        }
    }

    public void ShowMap()
    {
        MapJam.SetActive(true);
    }

    public void HideMap()
    {
        MapJam.SetActive(false);
    }
}
