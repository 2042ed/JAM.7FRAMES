using UnityEngine;
using System.Collections;

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

}
