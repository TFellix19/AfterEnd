using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fimdojogo : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.npecas == GameManager.tpecas)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            Debug.Log(GameManager.npecas + " de " + GameManager.tpecas);
        }
    }
}
