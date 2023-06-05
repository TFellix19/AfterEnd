using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string nome, tipo;
    [SerializeField]
    public float fome, sede, vida, dano;
    [SerializeField]
    public Texture2D icon;
    public Item (string Inome, string Itipo, float Ifome, float Isede, float Ivida , float Idano, Texture2D Iicon)
    {
        nome = Inome;
        tipo = Itipo;
        fome = Ifome;
        sede = Isede;
        vida = Ivida;
        dano = Idano;
        icon = Iicon;
    }
}
