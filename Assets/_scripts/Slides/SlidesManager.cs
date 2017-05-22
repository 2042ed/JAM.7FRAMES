using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidesManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI PageCounterLabel;

    List<GameObject> Slides = new List<GameObject>();

    int currentPage;
    int TotalPages;

    void Start()
    {
        currentPage = 1;

        foreach (Transform child in transform) {
            // Debug.Log(child.name);
            Slides.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        TotalPages = Slides.Count;
        ShowCurrentPage();
    }

    void Update()
    {
        // if PRESS SPACE -> next page
        if (Input.GetKeyDown(KeyCode.Space)) {
            SkipRight();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            SkipRight();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            SkipLeft();
        }
    }

    public void ChangePage(int newPage)
    {
        Slides[currentPage - 1].SetActive(false);
        currentPage = newPage;
        ShowCurrentPage();
    }

    public void ShowCurrentPage()
    {
        Slides[currentPage - 1].SetActive(true);
        PageCounterLabel.text = currentPage + " / " + TotalPages;
    }

    public void SkipRight()
    {
        if (currentPage < TotalPages) {
            ChangePage(currentPage + 1);
        }
    }

    public void SkipLeft()
    {
        if (currentPage > 1) {
            ChangePage(currentPage - 1);
        }
    }
}
