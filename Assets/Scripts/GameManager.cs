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
    public static int nbalas = 0;
    public static string textpecas;
    public static float fome, sede, vida, npecas = 0, tpecas = 5;
    float maxF = 100f, maxS = 100f, maxV = 100f;
    bool gameIsPaused;
    public static bool podedisparar, InvAberto;
    private static List<Item> inventory = new List<Item>();
    [SerializeField]
    private TMP_Text text;
    public static GameObject PauseMenu, ApanharE, Inv;
    public static Button btnselecionado;
    public static Button sair, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24, s25, s26, s27, s28, s29, s30, qd1, qd2, qd3, qd4, qd5, qd6, qd7, qd8, qd9, qd10;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        textpecas = "0/5 peças";
        podedisparar = true;
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
        Inv.SetActive(false);
        InvAberto = false;
        PauseMenu.SetActive(true);
        podedisparar = false;

    }
    //voltar ao jogo
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        podedisparar = true;
    }
    public void ConsumirItem()
    {
        btnselecionado = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Debug.Log("testes :" + btnselecionado.name);
        for (int i = 0; i < Inventario.inventario.Count; i++)
        {
            Debug.Log("item : " + i + Inventario.inventario[i].nome);
        }
        switch (btnselecionado.name)
        {
            case "slot1":
                if (s1.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[0].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[0].fome >= 100f) && (sede + Inventario.inventario[0].sede >= 100f))
                    {
                        Debug.Log("teste fome11 :" + fome);
                        Debug.Log("teste sede11 :" + sede);
                        Debug.Log("teste item fome1 :" + Inventario.inventario[0].fome);
                        Debug.Log("teste item sede1 :" + Inventario.inventario[0].sede);
                        
                        fome = 100f;
                        sede = 100f;
                        Debug.Log("teste fome1 :" + fome);
                        Debug.Log("teste sede1 :" + sede);
                        s1.image.sprite = default;
                        Inventario.inventario.RemoveAt(0);
                    }
                    else if ((fome + Inventario.inventario[0].fome >= 100f) && (sede + Inventario.inventario[0].sede < 100f))
                    {
                        Debug.Log("teste fome21 :" + fome);
                        Debug.Log("teste sede21 :" + sede);
                        Debug.Log("teste item fome2 :" + Inventario.inventario[0].fome);
                        Debug.Log("teste item sede2 :" + Inventario.inventario[0].sede);
                        
                        fome = 100f;
                        sede = sede + Inventario.inventario[0].sede;
                        Debug.Log("teste fome2 :" + fome);
                        Debug.Log("teste sede2 :" + sede);
                        s1.image.sprite = default;
                        Inventario.inventario.RemoveAt(0);
                    }
                    else if ((fome + Inventario.inventario[0].fome < 100f) && (sede + Inventario.inventario[0].sede >= 100f))
                    {
                        Debug.Log("teste fome31 :" + fome);
                        Debug.Log("teste sede31 :" + sede);
                        Debug.Log("teste item fome3 :" + Inventario.inventario[0].fome);
                        Debug.Log("teste item sede3 :" + Inventario.inventario[0].sede);
                        fome = fome + Inventario.inventario[0].fome;
                        sede = 100f;
                        Debug.Log("teste fome3 :" + fome);
                        Debug.Log("teste sede3 :" + sede);
                        s1.image.sprite = default;
                        Inventario.inventario.RemoveAt(0);
                    }
                    else if ((fome + Inventario.inventario[0].fome < 100f) && (sede + Inventario.inventario[0].sede < 100f))
                    {
                        Debug.Log("teste fome41 :" + fome);
                        Debug.Log("teste sede41 :" + sede);
                        Debug.Log("teste item fome4 :" + Inventario.inventario[0].fome);
                        Debug.Log("teste item sede4 :" + Inventario.inventario[0].sede);
                        fome = fome + Inventario.inventario[0].fome;
                        sede = sede + Inventario.inventario[0].sede;
                        Debug.Log("teste fome4 :" + fome);
                        Debug.Log("teste sede4 :" + sede);
                        s1.image.sprite = default;
                        Inventario.inventario.RemoveAt(0);
                    }
                }
                else if (Inventario.inventario[0].tipo == "vida")
                {
                    if (vida + Inventario.inventario[0].vida >= 100f)
                    {
                        vida = 100f;
                        s1.image.sprite = default;
                        Inventario.inventario.RemoveAt(0);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[0].vida;
                        s1.image.sprite = default;
                        Inventario.inventario.RemoveAt(0);
                    }
                    
                }
                break;
            case "slot2":
                if (s2.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[1].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[1].fome >= 100f) && (sede + Inventario.inventario[1].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s2.image.sprite = default;
                        Inventario.inventario.RemoveAt(1);
                    }
                    else if ((fome + Inventario.inventario[1].fome >= 100f) && (sede + Inventario.inventario[1].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[1].sede;
                        s2.image.sprite = default;
                        Inventario.inventario.RemoveAt(1);
                    }
                    else if ((fome + Inventario.inventario[1].fome < 100f) && (sede + Inventario.inventario[1].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[1].fome;
                        sede = 100f;
                        s2.image.sprite = default;
                        Inventario.inventario.RemoveAt(1);
                    }
                    else if ((fome + Inventario.inventario[1].fome < 100f) && (sede + Inventario.inventario[1].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[1].fome;
                        sede = sede + Inventario.inventario[1].sede;
                        s2.image.sprite = default;
                        Inventario.inventario.RemoveAt(1);
                    }
                }
                else if (Inventario.inventario[1].tipo == "vida")
                {
                    if (vida + Inventario.inventario[1].vida >= 100f)
                    {
                        vida = 100f;
                        s2.image.sprite = default;
                        Inventario.inventario.RemoveAt(1);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[1].vida;
                        s2.image.sprite = default;
                        Inventario.inventario.RemoveAt(1);
                    }
                }
                break;
            case "slot3":
                if (s3.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[2].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[2].fome >= 100f) && (sede + Inventario.inventario[2].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s3.image.sprite = default;
                        Inventario.inventario.RemoveAt(2);
                    }
                    else if ((fome + Inventario.inventario[2].fome >= 100f) && (sede + Inventario.inventario[2].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[2].sede;
                        s3.image.sprite = default;
                        Inventario.inventario.RemoveAt(2);
                    }
                    else if ((fome + Inventario.inventario[2].fome < 100f) && (sede + Inventario.inventario[2].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[2].fome;
                        sede = 100f;
                        s3.image.sprite = default;
                        Inventario.inventario.RemoveAt(2);
                    }
                    else if ((fome + Inventario.inventario[2].fome < 100f) && (sede + Inventario.inventario[2].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[2].fome;
                        sede = sede + Inventario.inventario[2].sede;
                        s3.image.sprite = default;
                        Inventario.inventario.RemoveAt(2);
                    }
                }
                else if (Inventario.inventario[2].tipo == "vida")
                {
                    if (vida + Inventario.inventario[2].vida >= 100f)
                    {
                        vida = 100f;
                        s3.image.sprite = default;
                        Inventario.inventario.RemoveAt(2);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[2].vida;
                        s3.image.sprite = default;
                        Inventario.inventario.RemoveAt(2);
                    }

                }
                break;
            case "slot4":
                if (s4.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[3].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[3].fome >= 100f) && (sede + Inventario.inventario[3].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s4.image.sprite = default;
                        Inventario.inventario.RemoveAt(3);
                    }
                    else if ((fome + Inventario.inventario[3].fome >= 100f) && (sede + Inventario.inventario[3].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[3].sede;
                        s4.image.sprite = default;
                        Inventario.inventario.RemoveAt(3);
                    }
                    else if ((fome + Inventario.inventario[3].fome < 100f) && (sede + Inventario.inventario[3].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[3].fome;
                        sede = 100f;
                        s4.image.sprite = default;
                        Inventario.inventario.RemoveAt(3);
                    }
                    else if ((fome + Inventario.inventario[3].fome < 100f) && (sede + Inventario.inventario[3].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[3].fome;
                        sede = sede + Inventario.inventario[3].sede;
                        s4.image.sprite = default;
                        Inventario.inventario.RemoveAt(3);
                    }
                }
                else if (Inventario.inventario[3].tipo == "vida")
                {
                    if (vida + Inventario.inventario[3].vida >= 100f)
                    {
                        vida = 100f;
                        s4.image.sprite = default;
                        Inventario.inventario.RemoveAt(3);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[3].vida;
                        s4.image.sprite = default;
                        Inventario.inventario.RemoveAt(3);
                    }

                }
                break;
            case "slot5":
                if (s5.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[4].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[4].fome >= 100f) && (sede + Inventario.inventario[4].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s5.image.sprite = default;
                        Inventario.inventario.RemoveAt(4);
                    }
                    else if ((fome + Inventario.inventario[4].fome >= 100f) && (sede + Inventario.inventario[4].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[4].sede;
                        s5.image.sprite = default;
                        Inventario.inventario.RemoveAt(4);
                    }
                    else if ((fome + Inventario.inventario[4].fome < 100f) && (sede + Inventario.inventario[4].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[4].fome;
                        sede = 100f;
                        s5.image.sprite = default;
                        Inventario.inventario.RemoveAt(4);
                    }
                    else if ((fome + Inventario.inventario[4].fome < 100f) && (sede + Inventario.inventario[4].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[4].fome;
                        sede = sede + Inventario.inventario[4].sede;
                        s5.image.sprite = default;
                        Inventario.inventario.RemoveAt(4);
                    }
                }
                else if (Inventario.inventario[4].tipo == "vida")
                {
                    if (vida + Inventario.inventario[4].vida >= 100f)
                    {
                        vida = 100f;
                        s5.image.sprite = default;
                        Inventario.inventario.RemoveAt(4);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[4].vida;
                        s5.image.sprite = default;
                        Inventario.inventario.RemoveAt(4);
                    }

                }
                break;
            case "slot6":
                if (s6.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[5].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[5].fome >= 100f) && (sede + Inventario.inventario[5].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s6.image.sprite = default;
                        Inventario.inventario.RemoveAt(5);
                    }
                    else if ((fome + Inventario.inventario[5].fome >= 100f) && (sede + Inventario.inventario[5].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[5].sede;
                        s6.image.sprite = default;
                        Inventario.inventario.RemoveAt(5);
                    }
                    else if ((fome + Inventario.inventario[5].fome < 100f) && (sede + Inventario.inventario[5].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[5].fome;
                        sede = 100f;
                        s6.image.sprite = default;
                        Inventario.inventario.RemoveAt(5);
                    }
                    else if ((fome + Inventario.inventario[5].fome < 100f) && (sede + Inventario.inventario[5].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[5].fome;
                        sede = sede + Inventario.inventario[5].sede;
                        s6.image.sprite = default;
                        Inventario.inventario.RemoveAt(5);
                    }
                }
                else if (Inventario.inventario[5].tipo == "vida")
                {
                    if (vida + Inventario.inventario[5].vida >= 100f)
                    {
                        vida = 100f;
                        s6.image.sprite = default;
                        Inventario.inventario.RemoveAt(5);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[5].vida;
                        s6.image.sprite = default;
                        Inventario.inventario.RemoveAt(5);
                    }

                }
                break;
            case "slot7":
                if (s7.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[6].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[6].fome >= 100f) && (sede + Inventario.inventario[6].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s7.image.sprite = default;
                        Inventario.inventario.RemoveAt(6);
                    }
                    else if ((fome + Inventario.inventario[6].fome >= 100f) && (sede + Inventario.inventario[6].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[6].sede;
                        s7.image.sprite = default;
                        Inventario.inventario.RemoveAt(6);
                    }
                    else if ((fome + Inventario.inventario[6].fome < 100f) && (sede + Inventario.inventario[6].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[6].fome;
                        sede = 100f;
                        s7.image.sprite = default;
                        Inventario.inventario.RemoveAt(6);
                    }
                    else if ((fome + Inventario.inventario[6].fome < 100f) && (sede + Inventario.inventario[6].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[6].fome;
                        sede = sede + Inventario.inventario[6].sede;
                        s7.image.sprite = default;
                        Inventario.inventario.RemoveAt(6);
                    }
                }
                else if (Inventario.inventario[6].tipo == "vida")
                {
                    if (vida + Inventario.inventario[6].vida >= 100f)
                    {
                        vida = 100f;
                        s7.image.sprite = default;
                        Inventario.inventario.RemoveAt(6);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[6].vida;
                        s7.image.sprite = default;
                        Inventario.inventario.RemoveAt(6);
                    }

                }
                break;
            case "slot8":
                if (s8.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[7].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[7].fome >= 100f) && (sede + Inventario.inventario[7].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s8.image.sprite = default;
                        Inventario.inventario.RemoveAt(7);
                    }
                    else if ((fome + Inventario.inventario[7].fome >= 100f) && (sede + Inventario.inventario[7].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[7].sede;
                        s8.image.sprite = default;
                        Inventario.inventario.RemoveAt(7);
                    }
                    else if ((fome + Inventario.inventario[7].fome < 100f) && (sede + Inventario.inventario[7].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[7].fome;
                        sede = 100f;
                        s8.image.sprite = default;
                        Inventario.inventario.RemoveAt(7);
                    }
                    else if ((fome + Inventario.inventario[7].fome < 100f) && (sede + Inventario.inventario[7].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[7].fome;
                        sede = sede + Inventario.inventario[7].sede;
                        s8.image.sprite = default;
                        Inventario.inventario.RemoveAt(7);
                    }
                }
                else if (Inventario.inventario[7].tipo == "vida")
                {
                    if (vida + Inventario.inventario[7].vida >= 100f)
                    {
                        vida = 100f;
                        s8.image.sprite = default;
                        Inventario.inventario.RemoveAt(7);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[7].vida;
                        s8.image.sprite = default;
                        Inventario.inventario.RemoveAt(7);
                    }

                }
                break;
            case "slot9":
                if (s9.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[8].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[8].fome >= 100f) && (sede + Inventario.inventario[8].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s9.image.sprite = default;
                        Inventario.inventario.RemoveAt(8);
                    }
                    else if ((fome + Inventario.inventario[8].fome >= 100f) && (sede + Inventario.inventario[8].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[8].sede;
                        s9.image.sprite = default;
                        Inventario.inventario.RemoveAt(8);
                    }
                    else if ((fome + Inventario.inventario[8].fome < 100f) && (sede + Inventario.inventario[8].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[8].fome;
                        sede = 100f;
                        s9.image.sprite = default;
                        Inventario.inventario.RemoveAt(8);
                    }
                    else if ((fome + Inventario.inventario[8].fome < 100f) && (sede + Inventario.inventario[8].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[8].fome;
                        sede = sede + Inventario.inventario[8].sede;
                        s9.image.sprite = default;
                        Inventario.inventario.RemoveAt(8);
                    }
                }
                else if (Inventario.inventario[8].tipo == "vida")
                {
                    if (vida + Inventario.inventario[8].vida >= 100f)
                    {
                        vida = 100f;
                        s9.image.sprite = default;
                        Inventario.inventario.RemoveAt(8);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[8].vida;
                        s9.image.sprite = default;
                        Inventario.inventario.RemoveAt(8);
                    }

                }
                break;
            case "slot10":
                if (s10.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[9].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[9].fome >= 100f) && (sede + Inventario.inventario[9].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s10.image.sprite = default;
                        Inventario.inventario.RemoveAt(9);
                    }
                    else if ((fome + Inventario.inventario[9].fome >= 100f) && (sede + Inventario.inventario[9].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[9].sede;
                        s10.image.sprite = default;
                        Inventario.inventario.RemoveAt(9);
                    }
                    else if ((fome + Inventario.inventario[9].fome < 100f) && (sede + Inventario.inventario[9].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[9].fome;
                        sede = 100f;
                        s10.image.sprite = default;
                        Inventario.inventario.RemoveAt(9);
                    }
                    else if ((fome + Inventario.inventario[9].fome < 100f) && (sede + Inventario.inventario[9].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[9].fome;
                        sede = sede + Inventario.inventario[9].sede;
                        s10.image.sprite = default;
                        Inventario.inventario.RemoveAt(9);
                    }
                }
                else if (Inventario.inventario[9].tipo == "vida")
                {
                    if (vida + Inventario.inventario[9].vida >= 100f)
                    {
                        vida = 100f;
                        s10.image.sprite = default;
                        Inventario.inventario.RemoveAt(9);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[9].vida;
                        s10.image.sprite = default;
                        Inventario.inventario.RemoveAt(9);
                    }

                }
                break;
            case "slot11":
                if (s11.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[10].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[10].fome >= 100f) && (sede + Inventario.inventario[10].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s11.image.sprite = default;
                        Inventario.inventario.RemoveAt(10);
                    }
                    else if ((fome + Inventario.inventario[10].fome >= 100f) && (sede + Inventario.inventario[10].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[10].sede;
                        s11.image.sprite = default;
                        Inventario.inventario.RemoveAt(10);
                    }
                    else if ((fome + Inventario.inventario[10].fome < 100f) && (sede + Inventario.inventario[10].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[10].fome;
                        sede = 100f;
                        s11.image.sprite = default;
                        Inventario.inventario.RemoveAt(10);
                    }
                    else if ((fome + Inventario.inventario[10].fome < 100f) && (sede + Inventario.inventario[10].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[10].fome;
                        sede = sede + Inventario.inventario[10].sede;
                        s11.image.sprite = default;
                        Inventario.inventario.RemoveAt(10);
                    }
                }
                else if (Inventario.inventario[10].tipo == "vida")
                {
                    if (vida + Inventario.inventario[10].vida >= 100f)
                    {
                        vida = 100f;
                        s11.image.sprite = default;
                        Inventario.inventario.RemoveAt(10);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[10].vida;
                        s11.image.sprite = default;
                        Inventario.inventario.RemoveAt(10);
                    }

                }
                break;
            case "slot12":
                if (s12.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[11].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[11].fome >= 100f) && (sede + Inventario.inventario[11].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s12.image.sprite = default;
                        Inventario.inventario.RemoveAt(11);
                    }
                    else if ((fome + Inventario.inventario[11].fome >= 100f) && (sede + Inventario.inventario[11].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[11].sede;
                        s12.image.sprite = default;
                        Inventario.inventario.RemoveAt(11);
                    }
                    else if ((fome + Inventario.inventario[11].fome < 100f) && (sede + Inventario.inventario[11].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[11].fome;
                        sede = 100f;
                        s12.image.sprite = default;
                        Inventario.inventario.RemoveAt(11);
                    }
                    else if ((fome + Inventario.inventario[11].fome < 100f) && (sede + Inventario.inventario[11].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[11].fome;
                        sede = sede + Inventario.inventario[11].sede;
                        s12.image.sprite = default;
                        Inventario.inventario.RemoveAt(11);
                    }
                }
                else if (Inventario.inventario[11].tipo == "vida")
                {
                    if (vida + Inventario.inventario[11].vida >= 100f)
                    {
                        vida = 100f;
                        s12.image.sprite = default;
                        Inventario.inventario.RemoveAt(11);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[11].vida;
                        s12.image.sprite = default;
                        Inventario.inventario.RemoveAt(11);
                    }
                }
                break;
            case "slot13":
                if (s13.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[12].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[12].fome >= 100f) && (sede + Inventario.inventario[12].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s13.image.sprite = default;
                        Inventario.inventario.RemoveAt(12);
                    }
                    else if ((fome + Inventario.inventario[12].fome >= 100f) && (sede + Inventario.inventario[12].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[12].sede;
                        s13.image.sprite = default;
                        Inventario.inventario.RemoveAt(12);
                    }
                    else if ((fome + Inventario.inventario[12].fome < 100f) && (sede + Inventario.inventario[12].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[12].fome;
                        sede = 100f;
                        s13.image.sprite = default;
                        Inventario.inventario.RemoveAt(12);
                    }
                    else if ((fome + Inventario.inventario[12].fome < 100f) && (sede + Inventario.inventario[12].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[12].fome;
                        sede = sede + Inventario.inventario[12].sede;
                        s13.image.sprite = default;
                        Inventario.inventario.RemoveAt(12);
                    }
                }
                else if (Inventario.inventario[12].tipo == "vida")
                {
                    if (vida + Inventario.inventario[12].vida >= 100f)
                    {
                        vida = 100f;
                        s13.image.sprite = default;
                        Inventario.inventario.RemoveAt(12);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[12].vida;
                        s13.image.sprite = default;
                        Inventario.inventario.RemoveAt(12);
                    }

                }
                break;
            case "slot14":
                if (s14.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[13].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[13].fome >= 100f) && (sede + Inventario.inventario[13].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s14.image.sprite = default;
                        Inventario.inventario.RemoveAt(13);
                    }
                    else if ((fome + Inventario.inventario[13].fome >= 100f) && (sede + Inventario.inventario[13].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[13].sede;
                        s14.image.sprite = default;
                        Inventario.inventario.RemoveAt(13);
                    }
                    else if ((fome + Inventario.inventario[13].fome < 100f) && (sede + Inventario.inventario[13].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[13].fome;
                        sede = 100f;
                        s14.image.sprite = default;
                        Inventario.inventario.RemoveAt(13);
                    }
                    else if ((fome + Inventario.inventario[13].fome < 100f) && (sede + Inventario.inventario[13].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[13].fome;
                        sede = sede + Inventario.inventario[13].sede;
                        s14.image.sprite = default;
                        Inventario.inventario.RemoveAt(13);
                    }
                }
                else if (Inventario.inventario[13].tipo == "vida")
                {
                    if (vida + Inventario.inventario[13].vida >= 100f)
                    {
                        vida = 100f;
                        s14.image.sprite = default;
                        Inventario.inventario.RemoveAt(13);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[13].vida;
                        s14.image.sprite = default;
                        Inventario.inventario.RemoveAt(13);
                    }

                }
                break;
            case "slot15":
                if (s15.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[14].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[14].fome >= 100f) && (sede + Inventario.inventario[14].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s15.image.sprite = default;
                        Inventario.inventario.RemoveAt(14);
                    }
                    else if ((fome + Inventario.inventario[14].fome >= 100f) && (sede + Inventario.inventario[14].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[14].sede;
                        s15.image.sprite = default;
                        Inventario.inventario.RemoveAt(14);
                    }
                    else if ((fome + Inventario.inventario[14].fome < 100f) && (sede + Inventario.inventario[14].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[14].fome;
                        sede = 100f;
                        s15.image.sprite = default;
                        Inventario.inventario.RemoveAt(14);
                    }
                    else if ((fome + Inventario.inventario[14].fome < 100f) && (sede + Inventario.inventario[14].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[14].fome;
                        sede = sede + Inventario.inventario[14].sede;
                        s15.image.sprite = default;
                        Inventario.inventario.RemoveAt(14);
                    }
                }
                else if (Inventario.inventario[14].tipo == "vida")
                {
                    if (vida + Inventario.inventario[14].vida >= 100f)
                    {
                        vida = 100f;
                        s15.image.sprite = default;
                        Inventario.inventario.RemoveAt(14);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[14].vida;
                        s15.image.sprite = default;
                        Inventario.inventario.RemoveAt(14);
                    }

                }
                break;
            case "slot16":
                if (s16.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[15].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[15].fome >= 100f) && (sede + Inventario.inventario[15].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s16.image.sprite = default;
                        Inventario.inventario.RemoveAt(15);
                    }
                    else if ((fome + Inventario.inventario[15].fome >= 100f) && (sede + Inventario.inventario[15].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[15].sede;
                        s16.image.sprite = default;
                        Inventario.inventario.RemoveAt(15);
                    }
                    else if ((fome + Inventario.inventario[15].fome < 100f) && (sede + Inventario.inventario[15].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[15].fome;
                        sede = 100f;
                        s16.image.sprite = default;
                        Inventario.inventario.RemoveAt(15);
                    }
                    else if ((fome + Inventario.inventario[15].fome < 100f) && (sede + Inventario.inventario[15].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[15].fome;
                        sede = sede + Inventario.inventario[15].sede;
                        s16.image.sprite = default;
                        Inventario.inventario.RemoveAt(15);
                    }
                }
                else if (Inventario.inventario[15].tipo == "vida")
                {
                    if (vida + Inventario.inventario[15].vida >= 100f)
                    {
                        vida = 100f;
                        s16.image.sprite = default;
                        Inventario.inventario.RemoveAt(15);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[15].vida;
                        s16.image.sprite = default;
                        Inventario.inventario.RemoveAt(15);
                    }

                }
                break;
            case "slot17":
                if (s17.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[16].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[16].fome >= 100f) && (sede + Inventario.inventario[16].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s17.image.sprite = default;
                        Inventario.inventario.RemoveAt(16);
                    }
                    else if ((fome + Inventario.inventario[16].fome >= 100f) && (sede + Inventario.inventario[16].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[16].sede;
                        s17.image.sprite = default;
                        Inventario.inventario.RemoveAt(16);
                    }
                    else if ((fome + Inventario.inventario[16].fome < 100f) && (sede + Inventario.inventario[16].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[16].fome;
                        sede = 100f;
                        s17.image.sprite = default;
                        Inventario.inventario.RemoveAt(16);
                    }
                    else if ((fome + Inventario.inventario[16].fome < 100f) && (sede + Inventario.inventario[16].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[16].fome;
                        sede = sede + Inventario.inventario[16].sede;
                        s17.image.sprite = default;
                        Inventario.inventario.RemoveAt(16);
                    }
                }
                else if (Inventario.inventario[16].tipo == "vida")
                {
                    if (vida + Inventario.inventario[16].vida >= 100f)
                    {
                        vida = 100f;
                        s17.image.sprite = default;
                        Inventario.inventario.RemoveAt(16);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[16].vida;
                        s17.image.sprite = default;
                        Inventario.inventario.RemoveAt(16);
                    }

                }
                break;
            case "slot18":
                if (s18.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[17].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[17].fome >= 100f) && (sede + Inventario.inventario[17].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s18.image.sprite = default;
                        Inventario.inventario.RemoveAt(17);
                    }
                    else if ((fome + Inventario.inventario[17].fome >= 100f) && (sede + Inventario.inventario[17].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[17].sede;
                        s18.image.sprite = default;
                        Inventario.inventario.RemoveAt(17);
                    }
                    else if ((fome + Inventario.inventario[17].fome < 100f) && (sede + Inventario.inventario[17].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[17].fome;
                        sede = 100f;
                        s18.image.sprite = default;
                        Inventario.inventario.RemoveAt(17);
                    }
                    else if ((fome + Inventario.inventario[17].fome < 100f) && (sede + Inventario.inventario[17].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[17].fome;
                        sede = sede + Inventario.inventario[17].sede;
                        s18.image.sprite = default;
                        Inventario.inventario.RemoveAt(17);
                    }
                }
                else if (Inventario.inventario[17].tipo == "vida")
                {
                    if (vida + Inventario.inventario[17].vida >= 100f)
                    {
                        vida = 100f;
                        s18.image.sprite = default;
                        Inventario.inventario.RemoveAt(17);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[17].vida;
                        s18.image.sprite = default;
                        Inventario.inventario.RemoveAt(17);
                    }

                }
                break;
            case "slot19":
                if (s19.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[18].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[18].fome >= 100f) && (sede + Inventario.inventario[18].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s19.image.sprite = default;
                        Inventario.inventario.RemoveAt(18);
                    }
                    else if ((fome + Inventario.inventario[18].fome >= 100f) && (sede + Inventario.inventario[18].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[18].sede;
                        s19.image.sprite = default;
                        Inventario.inventario.RemoveAt(18);
                    }
                    else if ((fome + Inventario.inventario[18].fome < 100f) && (sede + Inventario.inventario[18].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[18].fome;
                        sede = 100f;
                        s19.image.sprite = default;
                        Inventario.inventario.RemoveAt(18);
                    }
                    else if ((fome + Inventario.inventario[18].fome < 100f) && (sede + Inventario.inventario[18].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[18].fome;
                        sede = sede + Inventario.inventario[18].sede;
                        s19.image.sprite = default;
                        Inventario.inventario.RemoveAt(18);
                    }
                }
                else if (Inventario.inventario[18].tipo == "vida")
                {
                    if (vida + Inventario.inventario[18].vida >= 100f)
                    {
                        vida = 100f;
                        s19.image.sprite = default;
                        Inventario.inventario.RemoveAt(18);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[18].vida;
                        s19.image.sprite = default;
                        Inventario.inventario.RemoveAt(18);
                    }

                }
                break;
            case "slot20":
                if (s20.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[19].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[19].fome >= 100f) && (sede + Inventario.inventario[19].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s20.image.sprite = default;
                        Inventario.inventario.RemoveAt(19);
                    }
                    else if ((fome + Inventario.inventario[19].fome >= 100f) && (sede + Inventario.inventario[19].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[19].sede;
                        s20.image.sprite = default;
                        Inventario.inventario.RemoveAt(19);
                    }
                    else if ((fome + Inventario.inventario[19].fome < 100f) && (sede + Inventario.inventario[19].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[19].fome;
                        sede = 100f;
                        s20.image.sprite = default;
                        Inventario.inventario.RemoveAt(19);
                    }
                    else if ((fome + Inventario.inventario[19].fome < 100f) && (sede + Inventario.inventario[19].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[19].fome;
                        sede = sede + Inventario.inventario[19].sede;
                        s20.image.sprite = default;
                        Inventario.inventario.RemoveAt(19);
                    }
                }
                else if (Inventario.inventario[19].tipo == "vida")
                {
                    if (vida + Inventario.inventario[19].vida >= 100f)
                    {
                        vida = 100f;
                        s20.image.sprite = default;
                        Inventario.inventario.RemoveAt(19);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[19].vida;
                        s20.image.sprite = default;
                        Inventario.inventario.RemoveAt(19);
                    }

                }
                break;
            case "slot21":
                if (s21.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[20].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[20].fome >= 100f) && (sede + Inventario.inventario[20].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s21.image.sprite = default;
                        Inventario.inventario.RemoveAt(20);
                    }
                    else if ((fome + Inventario.inventario[20].fome >= 100f) && (sede + Inventario.inventario[20].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[20].sede;
                        s21.image.sprite = default;
                        Inventario.inventario.RemoveAt(20);
                    }
                    else if ((fome + Inventario.inventario[20].fome < 100f) && (sede + Inventario.inventario[20].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[20].fome;
                        sede = 100f;
                        s21.image.sprite = default;
                        Inventario.inventario.RemoveAt(20);
                    }
                    else if ((fome + Inventario.inventario[20].fome < 100f) && (sede + Inventario.inventario[20].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[20].fome;
                        sede = sede + Inventario.inventario[20].sede;
                        s21.image.sprite = default;
                        Inventario.inventario.RemoveAt(20);
                    }
                }
                else if (Inventario.inventario[20].tipo == "vida")
                {
                    if (vida + Inventario.inventario[20].vida >= 100f)
                    {
                        vida = 100f;
                        s21.image.sprite = default;
                        Inventario.inventario.RemoveAt(20);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[20].vida;
                        s21.image.sprite = default;
                        Inventario.inventario.RemoveAt(20);
                    }

                }
                break;
            case "slot22":
                if (s22.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[21].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[21].fome >= 100f) && (sede + Inventario.inventario[21].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s22.image.sprite = default;
                        Inventario.inventario.RemoveAt(21);
                    }
                    else if ((fome + Inventario.inventario[21].fome >= 100f) && (sede + Inventario.inventario[21].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[21].sede;
                        s22.image.sprite = default;
                        Inventario.inventario.RemoveAt(21);
                    }
                    else if ((fome + Inventario.inventario[21].fome < 100f) && (sede + Inventario.inventario[21].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[21].fome;
                        sede = 100f;
                        s22.image.sprite = default;
                        Inventario.inventario.RemoveAt(21);
                    }
                    else if ((fome + Inventario.inventario[21].fome < 100f) && (sede + Inventario.inventario[21].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[21].fome;
                        sede = sede + Inventario.inventario[21].sede;
                        s22.image.sprite = default;
                        Inventario.inventario.RemoveAt(21);
                    }
                }
                else if (Inventario.inventario[21].tipo == "vida")
                {
                    if (vida + Inventario.inventario[21].vida >= 100f)
                    {
                        vida = 100f;
                        s22.image.sprite = default;
                        Inventario.inventario.RemoveAt(21);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[21].vida;
                        s22.image.sprite = default;
                        Inventario.inventario.RemoveAt(21);
                    }
                }
                break;
            case "slot23":
                if (s23.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[22].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[22].fome >= 100f) && (sede + Inventario.inventario[22].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s23.image.sprite = default;
                        Inventario.inventario.RemoveAt(22);
                    }
                    else if ((fome + Inventario.inventario[22].fome >= 100f) && (sede + Inventario.inventario[22].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[22].sede;
                        s23.image.sprite = default;
                        Inventario.inventario.RemoveAt(22);
                    }
                    else if ((fome + Inventario.inventario[22].fome < 100f) && (sede + Inventario.inventario[22].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[22].fome;
                        sede = 100f;
                        s23.image.sprite = default;
                        Inventario.inventario.RemoveAt(22);
                    }
                    else if ((fome + Inventario.inventario[22].fome < 100f) && (sede + Inventario.inventario[22].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[22].fome;
                        sede = sede + Inventario.inventario[22].sede;
                        s23.image.sprite = default;
                        Inventario.inventario.RemoveAt(22);
                    }
                }
                else if (Inventario.inventario[22].tipo == "vida")
                {
                    if (vida + Inventario.inventario[22].vida >= 100f)
                    {
                        vida = 100f;
                        s23.image.sprite = default;
                        Inventario.inventario.RemoveAt(22);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[22].vida;
                        s23.image.sprite = default;
                        Inventario.inventario.RemoveAt(22);
                    }

                }
                break;
            case "slot24":
                if (s24.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[32].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[23].fome >= 100f) && (sede + Inventario.inventario[23].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s24.image.sprite = default;
                        Inventario.inventario.RemoveAt(23);
                    }
                    else if ((fome + Inventario.inventario[23].fome >= 100f) && (sede + Inventario.inventario[23].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[23].sede;
                        s24.image.sprite = default;
                        Inventario.inventario.RemoveAt(23);
                    }
                    else if ((fome + Inventario.inventario[23].fome < 100f) && (sede + Inventario.inventario[23].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[23].fome;
                        sede = 100f;
                        s24.image.sprite = default;
                        Inventario.inventario.RemoveAt(23);
                    }
                    else if ((fome + Inventario.inventario[23].fome < 100f) && (sede + Inventario.inventario[23].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[23].fome;
                        sede = sede + Inventario.inventario[23].sede;
                        s24.image.sprite = default;
                        Inventario.inventario.RemoveAt(23);
                    }
                }
                else if (Inventario.inventario[23].tipo == "vida")
                {
                    if (vida + Inventario.inventario[23].vida >= 100f)
                    {
                        vida = 100f;
                        s24.image.sprite = default;
                        Inventario.inventario.RemoveAt(23);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[23].vida;
                        s24.image.sprite = default;
                        Inventario.inventario.RemoveAt(23);
                    }

                }
                break;
            case "slot25":
                if (s25.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[24].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[24].fome >= 100f) && (sede + Inventario.inventario[24].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s25.image.sprite = default;
                        Inventario.inventario.RemoveAt(24);
                    }
                    else if ((fome + Inventario.inventario[24].fome >= 100f) && (sede + Inventario.inventario[24].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[24].sede;
                        s25.image.sprite = default;
                        Inventario.inventario.RemoveAt(24);
                    }
                    else if ((fome + Inventario.inventario[24].fome < 100f) && (sede + Inventario.inventario[24].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[24].fome;
                        sede = 100f;
                        s25.image.sprite = default;
                        Inventario.inventario.RemoveAt(24);
                    }
                    else if ((fome + Inventario.inventario[24].fome < 100f) && (sede + Inventario.inventario[24].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[24].fome;
                        sede = sede + Inventario.inventario[24].sede;
                        s25.image.sprite = default;
                        Inventario.inventario.RemoveAt(24);
                    }
                }
                else if (Inventario.inventario[24].tipo == "vida")
                {
                    if (vida + Inventario.inventario[24].vida >= 100f)
                    {
                        vida = 100f;
                        s25.image.sprite = default;
                        Inventario.inventario.RemoveAt(24);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[24].vida;
                        s25.image.sprite = default;
                        Inventario.inventario.RemoveAt(24);
                    }

                }
                break;
            case "slot26":
                if (s26.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[25].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[25].fome >= 100f) && (sede + Inventario.inventario[25].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s26.image.sprite = default;
                        Inventario.inventario.RemoveAt(25);
                    }
                    else if ((fome + Inventario.inventario[25].fome >= 100f) && (sede + Inventario.inventario[25].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[25].sede;
                        s26.image.sprite = default;
                        Inventario.inventario.RemoveAt(25);
                    }
                    else if ((fome + Inventario.inventario[25].fome < 100f) && (sede + Inventario.inventario[25].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[25].fome;
                        sede = 100f;
                        s26.image.sprite = default;
                        Inventario.inventario.RemoveAt(25);
                    }
                    else if ((fome + Inventario.inventario[25].fome < 100f) && (sede + Inventario.inventario[25].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[25].fome;
                        sede = sede + Inventario.inventario[25].sede;
                        s26.image.sprite = default;
                        Inventario.inventario.RemoveAt(25);
                    }
                }
                else if (Inventario.inventario[25].tipo == "vida")
                {
                    if (vida + Inventario.inventario[25].vida >= 100f)
                    {
                        vida = 100f;
                        s26.image.sprite = default;
                        Inventario.inventario.RemoveAt(25);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[25].vida;
                        s26.image.sprite = default;
                        Inventario.inventario.RemoveAt(25);
                    }

                }
                break;
            case "slot27":
                if (s27.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[26].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[26].fome >= 100f) && (sede + Inventario.inventario[26].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s27.image.sprite = default;
                        Inventario.inventario.RemoveAt(26);
                    }
                    else if ((fome + Inventario.inventario[26].fome >= 100f) && (sede + Inventario.inventario[26].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[26].sede;
                        s27.image.sprite = default;
                        Inventario.inventario.RemoveAt(26);
                    }
                    else if ((fome + Inventario.inventario[26].fome < 100f) && (sede + Inventario.inventario[26].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[26].fome;
                        sede = 100f;
                        s27.image.sprite = default;
                        Inventario.inventario.RemoveAt(26);
                    }
                    else if ((fome + Inventario.inventario[26].fome < 100f) && (sede + Inventario.inventario[26].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[26].fome;
                        sede = sede + Inventario.inventario[26].sede;
                        s27.image.sprite = default;
                        Inventario.inventario.RemoveAt(26);
                    }
                }
                else if (Inventario.inventario[26].tipo == "vida")
                {
                    if (vida + Inventario.inventario[26].vida >= 100f)
                    {
                        vida = 100f;
                        s27.image.sprite = default;
                        Inventario.inventario.RemoveAt(26);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[26].vida;
                        s27.image.sprite = default;
                        Inventario.inventario.RemoveAt(26);
                    }

                }
                break;
            case "slot28":
                if (s28.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[27].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[27].fome >= 100f) && (sede + Inventario.inventario[27].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s28.image.sprite = default;
                        Inventario.inventario.RemoveAt(27);
                    }
                    else if ((fome + Inventario.inventario[27].fome >= 100f) && (sede + Inventario.inventario[27].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[27].sede;
                        s28.image.sprite = default;
                        Inventario.inventario.RemoveAt(27);
                    }
                    else if ((fome + Inventario.inventario[27].fome < 100f) && (sede + Inventario.inventario[27].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[27].fome;
                        sede = 100f;
                        s28.image.sprite = default;
                        Inventario.inventario.RemoveAt(27);
                    }
                    else if ((fome + Inventario.inventario[27].fome < 100f) && (sede + Inventario.inventario[27].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[27].fome;
                        sede = sede + Inventario.inventario[27].sede;
                        s28.image.sprite = default;
                        Inventario.inventario.RemoveAt(27);
                    }
                }
                else if (Inventario.inventario[27].tipo == "vida")
                {
                    if (vida + Inventario.inventario[27].vida >= 100f)
                    {
                        vida = 100f;
                        s28.image.sprite = default;
                        Inventario.inventario.RemoveAt(27);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[27].vida;
                        s28.image.sprite = default;
                        Inventario.inventario.RemoveAt(27);
                    }

                }
                break;
            case "slot29":
                if (s29.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[28].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[28].fome >= 100f) && (sede + Inventario.inventario[28].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s29.image.sprite = default;
                        Inventario.inventario.RemoveAt(28);
                    }
                    else if ((fome + Inventario.inventario[28].fome >= 100f) && (sede + Inventario.inventario[28].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[28].sede;
                        s29.image.sprite = default;
                        Inventario.inventario.RemoveAt(28);
                    }
                    else if ((fome + Inventario.inventario[28].fome < 100f) && (sede + Inventario.inventario[28].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[28].fome;
                        sede = 100f;
                        s29.image.sprite = default;
                        Inventario.inventario.RemoveAt(28);
                    }
                    else if ((fome + Inventario.inventario[28].fome < 100f) && (sede + Inventario.inventario[28].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[28].fome;
                        sede = sede + Inventario.inventario[28].sede;
                        s29.image.sprite = default;
                        Inventario.inventario.RemoveAt(28);
                    }
                }
                else if (Inventario.inventario[28].tipo == "vida")
                {
                    if (vida + Inventario.inventario[28].vida >= 100f)
                    {
                        vida = 100f;
                        s29.image.sprite = default;
                        Inventario.inventario.RemoveAt(28);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[28].vida;
                        s29.image.sprite = default;
                        Inventario.inventario.RemoveAt(28);
                    }

                }
                break;
            case "slot30":
                if (s30.image.sprite == default)
                {
                    Debug.Log("vazio");
                }
                else if (Inventario.inventario[29].tipo == "comida")
                {
                    if ((fome + Inventario.inventario[29].fome >= 100f) && (sede + Inventario.inventario[29].sede >= 100f))
                    {
                        fome = 100f;
                        sede = 100f;
                        s30.image.sprite = default;
                        Inventario.inventario.RemoveAt(29);
                    }
                    else if ((fome + Inventario.inventario[29].fome >= 100f) && (sede + Inventario.inventario[29].sede < 100f))
                    {
                        fome = 100f;
                        sede = sede + Inventario.inventario[29].sede;
                        s30.image.sprite = default;
                        Inventario.inventario.RemoveAt(19);
                    }
                    else if ((fome + Inventario.inventario[29].fome < 100f) && (sede + Inventario.inventario[29].sede >= 100f))
                    {
                        fome = fome + Inventario.inventario[29].fome;
                        sede = 100f;
                        s30.image.sprite = default;
                        Inventario.inventario.RemoveAt(29);
                    }
                    else if ((fome + Inventario.inventario[29].fome < 100f) && (sede + Inventario.inventario[29].sede < 100f))
                    {
                        fome = fome + Inventario.inventario[29].fome;
                        sede = sede + Inventario.inventario[29].sede;
                        s30.image.sprite = default;
                        Inventario.inventario.RemoveAt(29);
                    }
                }
                else if (Inventario.inventario[29].tipo == "vida")
                {
                    if (vida + Inventario.inventario[29].vida >= 100f)
                    {
                        vida = 100f;
                        s30.image.sprite = default;
                        Inventario.inventario.RemoveAt(29);
                    }
                    else
                    {
                        vida = vida + Inventario.inventario[29].vida;
                        s30.image.sprite = default;
                        Inventario.inventario.RemoveAt(29);
                    }

                }
                break;

        }
        s1.image.sprite = default;
        s2.image.sprite = default;
        s3.image.sprite = default;
        s4.image.sprite = default;
        s5.image.sprite = default;
        s6.image.sprite = default;
        s7.image.sprite = default;
        s8.image.sprite = default;
        s9.image.sprite = default;
        s10.image.sprite = default;
        s11.image.sprite = default;
        s12.image.sprite = default;
        s13.image.sprite = default;
        s14.image.sprite = default;
        s15.image.sprite = default;
        s16.image.sprite = default;
        s17.image.sprite = default;
        s18.image.sprite = default;
        s19.image.sprite = default;
        s20.image.sprite = default;
        s21.image.sprite = default;
        s22.image.sprite = default;
        s23.image.sprite = default;
        s24.image.sprite = default;
        s25.image.sprite = default;
        s26.image.sprite = default;
        s27.image.sprite = default;
        s28.image.sprite = default;
        s29.image.sprite = default;
        s30.image.sprite = default;
        for (int i = 0; i < Inventario.inventario.Count; i++)
        {
            Debug.Log("Item: " + i + Inventario.inventario[i].nome);
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

    }
    public void FecharInv()
    {
        s1.image.sprite = default;
        s2.image.sprite = default;
        s3.image.sprite = default;
        s4.image.sprite = default;
        s5.image.sprite = default;
        s6.image.sprite = default;
        s7.image.sprite = default;
        s8.image.sprite = default;
        s9.image.sprite = default;
        s10.image.sprite = default;
        s11.image.sprite = default;
        s12.image.sprite = default;
        s13.image.sprite = default;
        s14.image.sprite = default;
        s15.image.sprite = default;
        s16.image.sprite = default;
        s17.image.sprite = default;
        s18.image.sprite = default;
        s19.image.sprite = default;
        s20.image.sprite = default;
        s21.image.sprite = default;
        s22.image.sprite = default;
        s23.image.sprite = default;
        s24.image.sprite = default;
        s25.image.sprite = default;
        s26.image.sprite = default;
        s27.image.sprite = default;
        s28.image.sprite = default;
        s29.image.sprite = default;
        s30.image.sprite = default;
        Time.timeScale = 1;
        InvAberto = false;
        Inv.SetActive(false);
        Cursor.visible = false;
        podedisparar = true;
    }

    public static bool HasEnoughAmmo()
    {
        return inventory.Exists(item => item.tipo == "bala" && item.quantidade > 0);
    }

    public static void ConsumeAmmo()
    {
        Item ammoItem = inventory.Find(item => item.tipo == "bala" && item.quantidade > 0);
        if (ammoItem != null)
        {
            ammoItem.quantidade--;
            if (ammoItem.quantidade <= 0)
            {
                inventory.Remove(ammoItem);
            }
        }
    }
    void Update()
    {
        //textbalas.text = nbalas.ToString();
        // se o esc for clickado o jogo fica paused ou unpaused
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("pause");
            if (pauseMenu.isPaused)
            {

            }
            else
            {
                InvAberto = !InvAberto;
                if (InvAberto)
                {
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    podedisparar = false;
                    Cursor.lockState = CursorLockMode.None;
                    for (int i = 0; i < Inventario.inventario.Count; i++)
                    {
                        Debug.Log("Item: " + i + Inventario.inventario[i].nome);
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
                else
                {
                    Time.timeScale = 1;
                    podedisparar = true;
                    Cursor.visible = false;
                    s1.image.sprite = default;
                    s2.image.sprite = default;
                    s3.image.sprite = default;
                    s4.image.sprite = default;
                    s5.image.sprite = default;
                    s6.image.sprite = default;
                    s7.image.sprite = default;
                    s8.image.sprite = default;
                    s9.image.sprite = default;
                    s10.image.sprite = default;
                    s11.image.sprite = default;
                    s12.image.sprite = default;
                    s13.image.sprite = default;
                    s14.image.sprite = default;
                    s15.image.sprite = default;
                    s16.image.sprite = default;
                    s17.image.sprite = default;
                    s18.image.sprite = default;
                    s19.image.sprite = default;
                    s20.image.sprite = default;
                    s21.image.sprite = default;
                    s22.image.sprite = default;
                    s23.image.sprite = default;
                    s24.image.sprite = default;
                    s25.image.sprite = default;
                    s26.image.sprite = default;
                    s27.image.sprite = default;
                    s28.image.sprite = default;
                    s29.image.sprite = default;
                    s30.image.sprite = default;
                    Inv.SetActive(false);
                }
            }
            
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
