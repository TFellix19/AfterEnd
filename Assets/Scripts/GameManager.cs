using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Slider SliderFome, SliderSede, SliderVida;
    public List<Item> Inventário = new List<Item>();
    public List<Item> QuickDraw = new List<Item>();
    public static float fome, sede, vida, nbalas= 0;
    float maxF = 100f, maxS = 100f, maxV = 100f;
    bool gameIsPaused, InvAberto;
    [SerializeField]
    public TMP_Text textbalas;
    public static GameObject PauseMenu, ApanharE, Inv;
    void Start()
    {
        /*
        textbalas = GetComponent<TMP_Text>();
        textbalas.text = "sdas";*/
        //no inicio do jogo a personagem começa com a fome sede e vida no máximo
        fome = maxF;
        sede = maxS;
        vida = maxV;
        //encontrar o menu de pause e todos os gameobjects do jogo e desativa o menu de pause
        PauseMenu = GameObject.Find("PauseMenu");
        ApanharE = GameObject.Find("ApanharItem");
        Inv = GameObject.Find("Inventario");
        ApanharE.SetActive(false);
        Inv.SetActive(false);
        PauseMenu.SetActive(false);
    } 
    //pausar o jogo
    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    //voltar ao jogo
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
    public void FecharInv()
    {
        Inv.SetActive(false);
    }
    void Update()
    {
        //textbalas.text = nbalas.ToString();
        // se o esc for clickado o jogo fica paused ou unpaused
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("pause");
            gameIsPaused = !gameIsPaused;
            if (gameIsPaused)
            {
                PauseGame();
            }
            else { ResumeGame(); }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("pause");
            InvAberto = !InvAberto;
            if (InvAberto)
            {
                Inv.SetActive(true);
            }
            else { Inv.SetActive(false); }
        }
        // if para testar se a personagem está viva
        if (vida <= 0f)
        {
            SceneManager.LoadScene("GameOver"); // se a vida estiver a 0 a personagem morreu e é carregada a scene de derrota
        }
        // if para testar se a personagem tem fome ou sede 
        if ((fome <= 0f) || (sede <= 0f))
        {
            vida -= 2f * Time.deltaTime; //se a fome ou sede estiverem a 0 a personagem começa a perder vida
        }
        else
        {
            fome -= 1f * Time.deltaTime; // perda gradual de fome
            sede -= 1f * Time.deltaTime; // perda gradual de sede
        }
        
        //atribui os valores de fome,sede e vida aos respecivos sliders (barras)
        SliderFome.value = fome; 
        SliderSede.value = sede;
        SliderVida.value = vida;

    }
}
