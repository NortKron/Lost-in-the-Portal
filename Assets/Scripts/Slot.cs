using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Slot : MonoBehaviour
{
	public Item item;

	private GameObject panelItemDescription;
	private GameObject inventorySlots;
	private GameObject dragSprite;

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
	}

	// Обновление слота как пустого
	public void UpdateSlot() 
	{
		this.item = null;
		GetComponent<Image>().sprite = null;
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

    #region MouseEvents
    public void OnPointerOver()
    {
		Debug.Log("OnMouseOver");

		if (dragSprite != null)
            dragSprite.GetComponent<Image>().enabled = false;
    }

    public void OnPointerExit()
    {
		Debug.Log("OnMouseExit");

		if (dragSprite != null)
            dragSprite.GetComponent<Image>().enabled = true;
    }

    public void OnPointerDown()
    {
		Debug.Log("OnMouseDown");

        dragSprite = new GameObject(this.name);
        dragSprite.AddComponent<Image>().sprite = GetComponent<Image>().sprite;
        dragSprite.GetComponent<Image>().enabled = false;

		dragSprite.transform.position = transform.position;
		dragSprite.transform.localScale = transform.localScale;
	}

    public void OnPointerUp()
    {
		Debug.Log("OnMouseUp");
		//Destroy(dragSprite);
	}

    public void OnPointerDrag()
    {
		Debug.Log("OnMouseDrag");
		Vector2 vc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragSprite.transform.position = vc;
    }
	#endregion MouseEvents
}
