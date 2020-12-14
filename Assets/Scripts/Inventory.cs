using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	private Canvas canvas;

	public GameObject player;
	public Transform inventorySlots;

	private GameObject panelItemDescription;

	private Items items;
	private Slot[] slots;

	[SerializeField]
	private List<Image> icons = new List<Image>();

	void Start()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
		items = player.GetComponent<Items>();

		// Получение всех ячеек
		slots = inventorySlots.GetComponentsInChildren<Slot>();

		//Debug.Log("Pae name : " + transform. .gameObject.name);

		// TODO: получиnь доступ к панели ItemDescription другим способом!!
		//panelItemDescription = transform.Find("ItemDescription").gameObject;
		panelItemDescription = GameObject.Find("ItemDescription").gameObject;
	}

	public void OnInventory()
	{
		// Set pause
		Time.timeScale = canvas.enabled ? 1 : 0;

		canvas.enabled = !canvas.enabled;
		Cursor.visible = canvas.enabled;

		if (canvas.enabled) UpdateUI();
	}

	void UpdateUI()
	{
		for (int i = 0; i < slots.Length; i++) //Проверка всех предметов
		{
			//Debug.Log("i : " + i);

			if (i < items.GetSize())
				slots[i].UpdateSlot(items.GetItem(i));
			else
				slots[i].UpdateSlot();

			//slots[i].UpdateSlot(items.GetItem(i).inventoryImage);
			//slots[i].UpdateSlot(items.spriteItems[i]);
		}
	}

	void SetItemDescription(string description)
    {
		panelItemDescription.GetComponent<Text>().text = description;
	}
}
