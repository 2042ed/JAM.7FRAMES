using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager I;

    public Fungus.Flowchart HomeFlowchart;

    public GameObject InventoryPanel;
    public GameObject ItemOlio1;
    public GameObject ItemOlio2;
    public GameObject ItemOlio3;
    public GameObject ItemDiario;
    public GameObject ItemPelliccia;
    public GameObject ItemChiaveItaliana;
    public GameObject ItemCodice;
    public GameObject ItemMedicina;
    public GameObject ItemAndroide;
    public GameObject ItemMorte;
    public GameObject ItemMap;
    public GameObject Map;
    public GameObject ItemDraghetto;
    public TMPro.TextMeshProUGUI ItemDraghettoLabel;

    int OilCounter;
    bool hasOlio1;
    bool hasOlio2;
    bool hasOlio3;
    bool hasDiario;
    bool hasPelliccia;
    bool hasChiaveItaliana;
    bool hasCodice;
    bool hasMedicina;
    bool hasAndroide;
    bool hasMorte;
    bool hasMap;
    int counterDraghetti;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        counterDraghetti = 0;
        Map.SetActive(false);
        resetInventory();
    }

    public void OpenInventory()
    {
        InventoryPanel.SetActive(true);
    }

    public void CloseInventory()
    {
        InventoryPanel.SetActive(false);
    }

    public void ClickItem(string quale)
    {
        switch (quale) {
            case "mappa":
                ToggleMap();
                break;
            default:
                HomeFlowchart.ExecuteBlock("item-" + quale);
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("m")) {
            Map.SetActive(true);
        }
        if (Input.GetKeyUp("m")) {
            Map.SetActive(false);
        }

    }

    public void ToggleMap()
    {
        if (Map.activeSelf) {
            HideMap();
        } else {
            ShowMap();
        }
    }

    public void ShowMap()
    {
        Map.SetActive(true);
    }

    public void HideMap()
    {
        Map.SetActive(false);
    }


    public void GetDraghetto()
    {
        counterDraghetti++;
        resetInventory();
        ClickItem("draghetto");
    }

    public void GetOlio1()
    {
        hasOlio1 = true;
        resetInventory();
    }

    public void GetOlio2()
    {
        hasOlio2 = true;
        resetInventory();
    }

    public void GetOlio3()
    {
        hasOlio3 = true;
        resetInventory();
    }

    public void GetDiario()
    {
        hasDiario = true;
        resetInventory();
    }

    public void GetPelliccia()
    {
        hasPelliccia = true;
        resetInventory();
    }

    public void GetChiaveItaliana()
    {
        hasChiaveItaliana = true;
        resetInventory();
    }

    public void GetCodice()
    {
        hasCodice = true;
        resetInventory();
    }
    public void GetMap()
    {
        hasMap = true;
        resetInventory();
        HomeFlowchart.ExecuteBlock("item-mappa");
    }

    public void GetMedicina()
    {
        hasMedicina = true;
        resetInventory();
    }

    public void GetAndroide()
    {
        hasAndroide = true;
        resetInventory();
    }

    public void GetMorte()
    {
        hasMorte = true;
        resetInventory();
    }

    public void LoseAllOil()
    {
        hasOlio1 = hasOlio2 = hasOlio3 = false;
        resetInventory();
    }

    public void LoseAndroide()
    {
        hasAndroide = false;
        resetInventory();
    }

    public void LoseDiario()
    {
        hasDiario = false;
        resetInventory();
    }

    public void LoseMedicina()
    {
        hasMedicina = false;
        resetInventory();
    }

    void resetInventory()
    {
        OilCounter = 0;
        if (hasOlio1) {
            OilCounter++;
        }
        if (hasOlio2) {
            OilCounter++;
        }
        if (hasOlio3) {
            OilCounter++;
        }
        ItemOlio1.SetActive(OilCounter == 1);
        ItemOlio2.SetActive(OilCounter == 2);
        ItemOlio3.SetActive(OilCounter == 3);

        ItemDiario.SetActive(hasDiario);
        ItemPelliccia.SetActive(hasPelliccia);
        ItemChiaveItaliana.SetActive(hasChiaveItaliana);
        ItemCodice.SetActive(hasCodice);
        ItemMedicina.SetActive(hasMedicina);
        ItemAndroide.SetActive(hasAndroide);
        ItemMorte.SetActive(hasMorte);
        ItemMap.SetActive(hasMap);

        ItemDraghetto.SetActive(counterDraghetti > 0);
        ItemDraghettoLabel.text = counterDraghetti + "/12";
    }
}
