using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string nome, tipo;
    [SerializeField]
    public float fome, sede, vida, dano, quantidade;
    [SerializeField]
    public Sprite icon;
    public Item (string Inome, string Itipo, float Ifome, float Iquantidade, float Isede, float Ivida , float Idano, Sprite Iicon)
    {
        nome = Inome;
        quantidade = Iquantidade;
        tipo = Itipo;
        fome = Ifome;
        sede = Isede;
        vida = Ivida;
        dano = Idano;
        icon = Iicon;
    }
}
