using UnityEngine;
using UnityEngine.UI;

public class TotalBulletsUI : MonoBehaviour
{
    public Gun gun;
    public Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    void Update()
    {
        textComponent.text = GameManager.nbalas.ToString();
    }
}
