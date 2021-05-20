using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
	[SerializeReference]
	private Item item;

	void OnTriggerEnter2D(Collider2D obj) //«Наезд» на объект
	{
		if (obj.transform.tag == "Player")
		{
			//Debug.Log("Name item : " + item.name);

			// Если наехал игрок, то он сможет подобрать предмет
			obj.GetComponent<Items>().AddItem(item);

			// Удаление объекта с карты
			Destroy(gameObject);
		}
	}
}
