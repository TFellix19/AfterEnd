using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class ControleSom : MonoBehaviour {

    public AudioMixer audioMixer;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

}
//https://www.youtube.com/watch?v=YOaYQrN1oYQ&t=75s&ab_channel=Brackeys