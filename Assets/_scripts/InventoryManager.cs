using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
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

    void Start()
    {
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
        if (hasOlio1) {
            ItemOlio1.SetActive(true);
            ItemOlio2.SetActive(false);
            ItemOlio3.SetActive(false);
        } else if (hasOlio3) {
            ItemOlio1.SetActive(false);
            ItemOlio2.SetActive(true);
            ItemOlio3.SetActive(false);
        } else if (hasOlio3) {
            ItemOlio1.SetActive(false);
            ItemOlio2.SetActive(false);
            ItemOlio3.SetActive(true);
        } else {
            ItemOlio1.SetActive(false);
            ItemOlio2.SetActive(false);
            ItemOlio3.SetActive(false);
        }

        ItemDiario.SetActive(hasDiario);
        ItemPelliccia.SetActive(hasPelliccia);
        ItemChiaveItaliana.SetActive(hasChiaveItaliana);
        ItemCodice.SetActive(hasCodice);
        ItemMedicina.SetActive(hasMedicina);
        ItemAndroide.SetActive(hasAndroide);
        ItemMorte.SetActive(hasMorte);
        ItemMap.SetActive(hasMap);
    }
}
