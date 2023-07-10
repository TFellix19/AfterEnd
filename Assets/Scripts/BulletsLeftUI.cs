using UnityEngine;
using UnityEngine.UI;

public class BulletsLeftUI : MonoBehaviour
{
    private Text textComponent;
    public Gun gun;
    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    void Update()
    {
        textComponent.text = gun.balas_carregador.ToString();
    }
}
