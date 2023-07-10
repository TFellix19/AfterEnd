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
                if (item.tipo == "peça")
                {
                    GameManager.npecas += 1;
                    Destroy(gameObject);
                    GameManager.textpecas = GameManager.npecas +"/5 peças";
                    Debug.Log("peças " + GameManager.npecas);
                    GameManager.ApanharE.SetActive(false);
                    podeapanhar = false;
                }
                else if (item.tipo == "bala")
                {
                    GameManager.nbalas += 1;
                    Debug.Log("balas " + GameManager.nbalas);
                    Destroy(gameObject);
                    GameManager.ApanharE.SetActive(false);
                    podeapanhar = false;
                }
                else if(inventory.AddItem(item))
                {
                   
                    Destroy(gameObject);
                    GameManager.ApanharE.SetActive(false);
                    podeapanhar = false;
                }

            }
        }
    }
}
