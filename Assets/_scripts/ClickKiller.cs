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
            Debug.Log("Extra curtains needed for " + gameObject.name);
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
        Debug.Log(gameObject.name + " ClickKiller.OnEnable()");
        if (curtains != null)
        {
            curtains.SetActive(true);
        }
    }

    void OnDisable()
    {
        Debug.Log(gameObject.name + " ClickKiller.OnDisable()");
        if (curtains != null)
        {
            curtains.SetActive(false);
        }
    }
}
