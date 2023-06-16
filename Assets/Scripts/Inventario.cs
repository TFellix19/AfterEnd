using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public int slotsI = 30;
    public int slotsQD = 10;
    public static List<Item> inventario = new List<Item>();
    public List<Item> QuickDraw = new List<Item>();
    // Start is called before the first frame update
    public bool AddItem(Item item)
    {
        if (inventario.Count < slotsI)
        {
           
            inventario.Add(item);
            return true;
        }
        else
        {
            Debug.Log("Inventário cheio!");
            return false;
        }
    }
}
