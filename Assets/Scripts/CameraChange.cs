using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    /*https://www.youtube.com/watch?v=nR5P7AH4aHE&ab_channel=JimmyVegas */

    public GameObject ThirdCam;
    public GameObject FirstCam;
    public int CamMode;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Camera"))
        {
            if (CamMode == 1)
            {
                CamMode = 0;
            }
            else
            {
                CamMode += 1;
            }
            StartCoroutine(CamChange());
        }        
    }
    IEnumerator CamChange ()
    {
        yield return new WaitForSeconds(0.01f);

        if (CamMode == 0)
        {
            ThirdCam.SetActive(true);
            FirstCam.SetActive(false);   
        }
        if (CamMode == 1)
        {
            ThirdCam.SetActive(false);
            FirstCam.SetActive(true);
        }
    }
}