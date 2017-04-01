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
    public GameObject ItemInvenzione;
    public GameObject ItemCodice;
    public GameObject ItemMedicina;
    public GameObject ItemAndroide;

    bool hasOlio1;
    bool hasOlio2;
    bool hasOlio3;
    bool hasDiario;
    bool hasPelliccia;
    bool hasChiaveItaliana;
    bool hasInvenzione;
    bool hasCodice;
    bool hasMedicina;
    bool hasAndroide;

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

    public void GetInvenzione()
    {
        hasInvenzione = true;
        resetInventory();
    }

    public void GetCodice()
    {
        hasCodice = true;
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

    void resetInventory()
    {
        ItemOlio1.SetActive(hasOlio1);
        ItemOlio2.SetActive(hasOlio2);
        ItemOlio3.SetActive(hasOlio3);
        ItemDiario.SetActive(hasDiario);
        ItemPelliccia.SetActive(hasPelliccia);
        ItemChiaveItaliana.SetActive(hasChiaveItaliana);
        ItemInvenzione.SetActive(hasInvenzione);
        ItemCodice.SetActive(hasCodice);
        ItemMedicina.SetActive(hasMedicina);
        ItemAndroide.SetActive(hasAndroide);
    }
}
