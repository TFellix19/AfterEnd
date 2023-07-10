using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public Image On;
    public Image Off;
    public Image On1;
    public Image Off1;
    public Image img;
    public Image img1;
    public Slider slider;
    public Slider slider1;
    int index;

    public AudioSource audioSource;

    void Start()
    {
        slider.value = audioSource.volume;
    }


    void Update()
    {
        if(index == 3)
        {
            slider1.gameObject.SetActive(false);
            img1.gameObject.SetActive(false);
        }

        if(index == 2)
        {
            slider1.gameObject.SetActive(true);
            img1.gameObject.SetActive(true);

        }
        if (index == 1)
        {
            slider.gameObject.SetActive(false);
            img.gameObject.SetActive(false);
        }

        if (index == 0)
        {
            
            slider.gameObject.SetActive(true);
            img.gameObject.SetActive(true);
        }
    }

    public void ON()
    {
        index = 1;
        Off.gameObject.SetActive(true);
        On.gameObject.SetActive(false);
        audioSource.volume = -80f;

    }

        public void OFF()
    {
        index = 0;
        On.gameObject.SetActive(true);
        Off.gameObject.SetActive(false);
        audioSource.volume = 80f;
    }

    public void ON1()
    {
        index = 3;
        Off1.gameObject.SetActive(true);
        On1.gameObject.SetActive(false);
        audioSource.volume = -80f;
    }

    public void OFF1()
    {
        index = 2;
        On1.gameObject.SetActive(true);
        Off1.gameObject.SetActive(false);
        audioSource.volume = 80f;
    }
}
