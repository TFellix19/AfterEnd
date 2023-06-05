using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    public Item item; // O item associado a este objeto
    bool podeapanhar;
    [SerializeField]
    public GameObject Player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.ApanharE.SetActive(true);
            podeapanhar = true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.ApanharE.SetActive(false);
            podeapanhar = false;

        }
    }
    private void Update()
    {
        if (podeapanhar == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("carrgounoE");
                Inventario inventory = Player.GetComponent<Inventario>();
                if (inventory.AddItem(item))
                {
                    if (item.tipo == "comida")
                    {
                        GameManager.fome = GameManager.fome + item.fome;
                        GameManager.sede = GameManager.sede + item.sede;
                    }
                    if (item.tipo == "vida")
                    {
                        GameManager.vida = GameManager.vida + item.vida;
                        
                    }
                    if (item.tipo == "balas")
                    {
                        GameManager.nbalas = GameManager.nbalas + 1;
                    }
                    if (item.tipo == "arma")
                    {
                        GameManager.nbalas = GameManager.nbalas + 1;
                    }
                    Destroy(gameObject);
                    GameManager.ApanharE.SetActive(false);
                    podeapanhar = false;
                }

            }
        }
    }
}
