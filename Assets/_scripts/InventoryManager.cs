using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryPanel;
    public GameObject Pelliccia;

    void Start()
    {

    }

    public void OpenInventory()
    {
        InventoryPanel.SetActive(true);
    }

    public void CloseInventory()
    {
        InventoryPanel.SetActive(false);
    }
}
