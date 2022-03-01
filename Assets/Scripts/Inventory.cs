using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    public void PickupItem(Item i)
    {
        items.Add(i);
    }

    public List<Item> GetItems()
    {
        return items;
    }



    public Item DropItem(int index)
    {
        if (items.Count <= index || index < 0)
        {

            return null;
        }
        Item i  = items[index];
        items.RemoveAt(index);
        return i;
    }


    public Item DropItem(string name)
    {
        for (int i = 0; i < items.Count; i++) 
        
        {
            if(items[i].item_name == name)
            {
                DropItem(i);
            }
        
        }
        return null;

    }
}
