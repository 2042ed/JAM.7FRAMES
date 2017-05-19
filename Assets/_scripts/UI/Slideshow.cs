using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slideshow : MonoBehaviour
{
    public float changeTime = 10.0f;
    public Sprite[] Slides;

    int currentSlide = 0;
    float timeSinceLast = 1.0f;
    Image myImg;

    void Awake()
    {
        myImg = gameObject.GetComponent<Image>();
    }

    void Start()
    {
        ChangeSlide();
    }

    void ChangeSlide()
    {
        if (currentSlide >= Slides.Length) {
            currentSlide = 0;
        }
        myImg.sprite = Slides[currentSlide];
    }

    void Update()
    {
        if (timeSinceLast > changeTime) {
            timeSinceLast = 0.0f;
            currentSlide++;
            ChangeSlide();
            // Debug.Log("inage " + currentSlide);
        }
        timeSinceLast += Time.deltaTime;
    }
}