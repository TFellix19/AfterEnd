using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pecasUI : MonoBehaviour
{
    private TMP_Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = GameManager.textpecas;
    }
}

