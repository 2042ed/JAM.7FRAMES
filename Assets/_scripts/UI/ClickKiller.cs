using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickKiller : MonoBehaviour {

    private static List<GameObject> curtainsList = new List<GameObject>();
    public GameObject curtains;

    void Awake()
    {
        if (curtainsList.Contains(curtains))
        {
            GameObject oldCurtains = curtains;
            curtains = Instantiate(oldCurtains, oldCurtains.transform.parent);         
            curtains.name = oldCurtains.name + " #" + (curtainsList.Count + 1);
        }
        curtainsList.Add(curtains);
    }

	void Start () {
    }
	
	void Update () {
		
	}

    void OnEnable()
    {        
        if (curtains != null)
        {
            curtains.SetActive(true);
        }
    }

    void OnDisable()
    {
        if (curtains != null)
        {
            curtains.SetActive(false);
        }
    }
}
