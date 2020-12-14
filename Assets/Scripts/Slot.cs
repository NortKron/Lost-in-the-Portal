using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Slot : MonoBehaviour
{
	public Item item;
	public int amount;

	private GameObject panelItemDescription;
	private GameObject inventorySlots;

	void Start()
    {
		// TODO: получиь доступ к панели InventoryCanvas другим способом!!
		//inventorySlots = transform. parent. parent.parent.gameObject;
		inventorySlots = GameObject.Find("InventoryCanvas");

		//Debug.Log("Parent name : " + transform.parent.gameObject.name );
		//Debug.Log("Parent Parent name : " + transform.parent.parent.gameObject.name);
		//Debug.Log("Parent Parent Parent name : " + transform.parent.parent.parent.gameObject.name);
	}

	// Обновление слота
	public void UpdateSlot(Item item) 
	{
		this.item = item;
		GetComponent<Image>().sprite = item.inventoryImage;
		GetComponentInChildren<Text>().enabled = false;
	}

	// Обновление слота как пустого
	public void UpdateSlot() 
	{
		this.item = null;
		GetComponent<Image>().sprite = null;
		GetComponentInChildren<Text>().enabled = true;
	}

	public void OnPressed()
    {
		// Click slot - get description
		
		// TODO : проверка item
		if (GetComponent<Image>().sprite != null)
		{
			inventorySlots.SendMessage("SetItemDescription",
				"Item name : " + item.ItemName
					+ "\nAmount : " + item.Amount
					+ "\nItem info : " + item.ItemDecription);
		}
	}
}
