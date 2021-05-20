using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
	//[SerializeField]
	private List<Item> items = new List<Item>();

	[SerializeField]
	//private int size = 9;

	/*
    void Start()
    {
		// TODO : Определить размер инвентаря
		//size = 
	}
	*/

	public bool AddItem(Item item, int amount = 1)
	{		
		foreach(Item itm in items)
        {
			if (itm.ItemID == item.ItemID)
            {
				itm.Amount++;
				return true;
            }
        }
		
		//if (items.Count >= size) return false;

		items.Add(item);

		return true;
	}

	public Item GetItem(int i)
    {
		return items[i];
		//return i < items.Count ? items[i] : null;
    }

	public int GetSize() => items.Count;
}
