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
    public static float fome, sede, vida, nbalas= 0;
    float maxF = 100f, maxS = 100f, maxV = 100f;
    bool gameIsPaused, InvAberto;
    [SerializeField]
    public TMP_Text textbalas;
    public static GameObject PauseMenu, ApanharE, Inv;
    public static Button sair, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24, s25, s26, s27, s28, s29, s30, qd1, qd2, qd3, qd4, qd5, qd6, qd7, qd8, qd9, qd10;
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
        sair = GameObject.Find("sair").GetComponent<Button>();
        s1 = GameObject.Find("slot1").GetComponent<Button>();
        s2 = GameObject.Find("slot2").GetComponent<Button>();
        s3 = GameObject.Find("slot3").GetComponent<Button>();
        s4 = GameObject.Find("slot4").GetComponent<Button>();
        s5 = GameObject.Find("slot5").GetComponent<Button>();
        s6 = GameObject.Find("slot6").GetComponent<Button>();
        s7 = GameObject.Find("slot7").GetComponent<Button>();
        s8 = GameObject.Find("slot8").GetComponent<Button>();
        s9 = GameObject.Find("slot9").GetComponent<Button>();
        s10 = GameObject.Find("slot10").GetComponent<Button>();
        s11 = GameObject.Find("slot11").GetComponent<Button>();
        s12 = GameObject.Find("slot12").GetComponent<Button>();
        s13 = GameObject.Find("slot13").GetComponent<Button>();
        s14 = GameObject.Find("slot14").GetComponent<Button>();
        s15 = GameObject.Find("slot15").GetComponent<Button>();
        s16 = GameObject.Find("slot16").GetComponent<Button>();
        s17 = GameObject.Find("slot17").GetComponent<Button>();
        s18 = GameObject.Find("slot18").GetComponent<Button>();
        s19 = GameObject.Find("slot19").GetComponent<Button>();
        s20 = GameObject.Find("slot20").GetComponent<Button>();
        s21 = GameObject.Find("slot21").GetComponent<Button>();
        s22 = GameObject.Find("slot22").GetComponent<Button>();
        s23 = GameObject.Find("slot23").GetComponent<Button>();
        s24 = GameObject.Find("slot24").GetComponent<Button>();
        s25 = GameObject.Find("slot25").GetComponent<Button>();
        s26 = GameObject.Find("slot26").GetComponent<Button>();
        s27 = GameObject.Find("slot27").GetComponent<Button>();
        s28 = GameObject.Find("slot28").GetComponent<Button>();
        s29 = GameObject.Find("slot29").GetComponent<Button>();
        s30 = GameObject.Find("slot30").GetComponent<Button>();
        qd1 = GameObject.Find("qd1").GetComponent<Button>();
        qd2 = GameObject.Find("qd2").GetComponent<Button>();
        qd3 = GameObject.Find("qd3").GetComponent<Button>();
        qd4 = GameObject.Find("qd4").GetComponent<Button>();
        qd5 = GameObject.Find("qd5").GetComponent<Button>();
        qd6 = GameObject.Find("qd6").GetComponent<Button>();
        qd7 = GameObject.Find("qd7").GetComponent<Button>();
        qd8 = GameObject.Find("qd8").GetComponent<Button>();
        qd9 = GameObject.Find("qd9").GetComponent<Button>();
        qd10 = GameObject.Find("qd10").GetComponent<Button>();
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
        Time.timeScale = 1;
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
                Time.timeScale = 0;
                for (int i = 0; i < Inventario.inventario.Count; i++)
                {
                    Debug.Log("Item: "+ i + Inventario.inventario[i].nome);
                        switch (i)
                        {
                            case 0:
                                s1.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 1:
                                s2.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 2:
                                s3.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 3:
                                s4.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 4:
                                s5.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 5:
                                s6.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 6:
                                s7.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 7:
                                s8.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 8:
                                s9.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 9:
                                s10.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 10:
                                s11.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 11:
                                s12.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 12:
                                s13.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 13:
                                s14.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 14:
                                s15.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 15:
                                s16.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 16:
                                s17.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 17:
                                s18.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 18:
                                s19.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 19:
                                s20.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 20:
                                s21.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 21:
                                s22.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 22:
                                s23.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 23:
                                s24.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 24:
                                s25.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 25:
                                s26.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 26:
                                s27.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 27:
                                s28.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 28:
                                s29.image.sprite = Inventario.inventario[i].icon;
                                break;
                            case 29:
                                s30.image.sprite = Inventario.inventario[i].icon;
                                break;
                        }
                    
                }
                Inv.SetActive(true);
            }
            else {
                Time.timeScale = 1;
                Inv.SetActive(false); }
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
